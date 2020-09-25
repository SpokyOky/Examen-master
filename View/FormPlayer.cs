using Logic.BindingModel;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Unity;

namespace View
{
    public partial class FormPlayer : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IPlayer Player;

        private readonly IGame Game;

        private int? id;

        public FormPlayer(IPlayer service, IGame GameService)
        {
            InitializeComponent();
            this.Player = service;
            this.Game = GameService;
        }

        private void FormPlayer_Load(object sender, EventArgs e)
        {
            var list = Game.Read(null);
            if (list != null)
            {
                comboBox1.DataSource = list;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }
            if (id.HasValue)
            {
                try
                {
                    var view = Player.Read(new PlayerBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxFullName.Text = view.PlayerName;
                        textBoxScore.Text = view.Score.ToString();
                        dateTimePicker1.Value = view.DateDeath;
                        textBoxType.Text = view.Type;
                        comboBox1.SelectedIndex = view.GameId - 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFullName.Text))
            {
                MessageBox.Show("Введите название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Выберите игру", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Player.CreateOrUpdate(new PlayerBindingModel
                {
                    Id = id,
                    PlayerName = textBoxFullName.Text,
                    Score = Convert.ToInt32(textBoxScore.Text),
                    Type = textBoxType.Text,
                    DateDeath = dateTimePicker1.Value,
                    GameId = Convert.ToInt32(comboBox1.SelectedValue)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
