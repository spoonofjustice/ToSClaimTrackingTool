using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ToSClaimTrackingTool.Models;
using ToSClaimTrackingTool.Models.ServerMessages;

namespace ToSClaimTrackingTool.UserControls.Chat
{
    public partial class ChatBox : UserControl
    {
        private readonly Dictionary<GameTime, List<ChatMessage>> _messageByTime = new Dictionary<GameTime, List<ChatMessage>>();
        private readonly List<ChatLineLabel> _chatLabels = new List<ChatLineLabel>();
        private event MouseEventHandler _mouseWheelHandler;
        private const int _labelHeight = 18;
        private int _lastLabelIndexUsed = -1;
        private int _lastLabelPos = 0;
        private GameTime _currentGameTime;

        public ChatBox()
        {
            InitializeComponent();
            _mouseWheelHandler = new MouseEventHandler(This_MouseWheel);
            timeSelector.SetGameTimeSelectedCallback(Display);
        }

        public void Clear()
        {
            _lastLabelIndexUsed = -1;
            _lastLabelPos = 0;
            _currentGameTime = null;
            _messageByTime.Clear();
            timeSelector.Clear();
            _chatLabels.ForEach(cl => cl.Visible = false);
        }

        public void DoUpdate() => _chatLabels.ForEach(cl => cl.DoUpdate());

        public void Add(ServerMessage serverMessage)
        {
            if (serverMessage.GetType() != typeof(ChatMessage)) return;
            var message = (ChatMessage)serverMessage;

            EnsureGameTimeExists(message.Time);
            _messageByTime[message.Time].Add(message);

            if (message.Time == _currentGameTime)
            {
                AddMessageToPanel(message);
                ScrollDownToLastLabel();
            }
        }

        private void EnsureGameTimeExists(GameTime gameTime)
        {
            if (!_messageByTime.ContainsKey(gameTime))
            {
                _messageByTime.Add(gameTime, new List<ChatMessage>());
                timeSelector.Add(gameTime, true);
            }
        }

        public void Display(GameTime gameTime)
        {
            _currentGameTime = gameTime;
            _lastLabelIndexUsed = -1;
            _lastLabelPos = 0;

            _messageByTime[gameTime].ForEach(AddMessageToPanel);
            RemoveUnusedLabels();
            //ScrollDownToLastLabel();

            int lastIndex = pChatLines.Controls.Count - 1;
            if (lastIndex > 0)
                pChatLines.Controls[lastIndex].Focus();
        }

        private void AddMessageToPanel(ChatMessage message)
        {
            var nextLabel = GetNextLabel();
            nextLabel.Top = _lastLabelPos + pChatLines.AutoScrollPosition.Y;
            nextLabel.SetMessage(message);
            nextLabel.Visible = true;

            _lastLabelPos += ScrollStopPixelCount;
        }
        public ChatLineLabel GetNextLabel()
        {
            _lastLabelIndexUsed++;
            int index = _lastLabelIndexUsed;

            if (_chatLabels.Count <= index)
            {
                var newLabel = new ChatLineLabel(_mouseWheelHandler);
                _chatLabels.Add(newLabel);
                pChatLines.Controls.Add(newLabel);
            }

            return _chatLabels[index];
        }

        private void RemoveUnusedLabels()
        {
            for (int i = _lastLabelIndexUsed + 1; i < _chatLabels.Count; i++)
            {
                pChatLines.Controls[i].Visible = false;
            }
        }
        private void ScrollDownToLastLabel()
        {
            int amountOfExceedingLabels = _lastLabelIndexUsed - 18;
            if (amountOfExceedingLabels > 0)
            {
                pChatLines.AutoScrollPosition = new Point(0, CleanScrollPos + amountOfExceedingLabels * ScrollStopPixelCount);
            }
        }

        private void This_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == 0) return;
            int scrollDirection = e.Delta > 0 ? -1 : 1;
            pChatLines.AutoScrollPosition = new Point(0, CleanScrollPos + ScrollStopPixelCount * scrollDirection);
        }

        private int CleanScrollPos => Offset > 0 ? ScrollPos - Offset : ScrollPos;
        private int ScrollPos => pChatLines.DisplayRectangle.Y * -1;
        private int Offset => ScrollPos % ScrollStopPixelCount;
        private int ScrollStopPixelCount => _labelHeight - 1;
    }
}
