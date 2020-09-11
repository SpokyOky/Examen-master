using Logic.BindingModel;
using Logic.BuisnessLogic;
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
using Unity;

namespace View
{
    public partial class FormGames : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IGame Game;

        private readonly BackUpAbstractLogic backUpAbstractLogic;

        public FormGames(IGame Game, BackUpAbstractLogic backUpAbstractLogic)
        {
            InitializeComponent();
            this.Game = Game;
            this.backUpAbstractLogic = backUpAbstractLogic;
        }

        private void FormGames_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = Game.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormGame>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonCh_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormGame>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        Game.Delete(new GameBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReport>();
            form.ShowDialog();
        }

        private void игрокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPlayers>();
            form.ShowDialog();
        }

        private void сохранитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        backUpAbstractLogic.CreateArchive(fbd.SelectedPath);
                        MessageBox.Show("Файл сохранен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
