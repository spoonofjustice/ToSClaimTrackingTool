using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ToSClaimTrackingTool.Models;

namespace ToSClaimTrackingTool.UserControls.Chat
{
    public partial class ChatTimeSelector : UserControl
    {
        private readonly EventHandler _radButtonCheckedEventHandler;
        private readonly List<GameTime> _gameTimes = new List<GameTime>();
        private Action<GameTime> _gameTimeSelectedCallback;
        private RadioButton _lastButton;

        public ChatTimeSelector()
        {
            InitializeComponent();
            _radButtonCheckedEventHandler = new EventHandler(RadButtonCheckedChanged);
        }

        public void Clear()
        {
            _gameTimes.Clear();
            Controls.Clear();
            _lastButton = null;
        }

        public void Add(GameTime gameTime, bool selectNew)
        {
            _gameTimes.Add(gameTime);
            AddRadioButton(gameTime);

            if (selectNew) _lastButton.Checked = true;
        }
        public void SetGameTimeSelectedCallback(Action<GameTime> gameTimeSelectedCallback) => _gameTimeSelectedCallback = gameTimeSelectedCallback;

        private void AddRadioButton(GameTime gameTime)
        {
            var radButton = new RadioButton
            {
                Text = gameTime.Text,
                Appearance = Appearance.Button,
                UseVisualStyleBackColor = true,
                AutoSize = true
            };

            radButton.Location = new Point((_lastButton?.Left ?? 0) + (_lastButton?.Width ?? 0) + 3, 6);
            radButton.CheckedChanged += _radButtonCheckedEventHandler;

            Controls.Add(radButton);
            _lastButton = radButton;
        }

        private void RadButtonCheckedChanged(object sender, EventArgs e)
        {
            var button = (RadioButton)sender;
            if (!button.Checked) return;

            _gameTimeSelectedCallback?.Invoke(_gameTimes.FirstOrDefault(gt => gt.Text.Equals(button.Text)));
        }
    }
}
