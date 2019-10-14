using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateDatafixRegistry
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtRelease_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                TbRelease.Text = fbd.SelectedPath;
            }

            if (Directory.Exists(TbRelease.Text))
            {
                DirectoryInfo releaseDir = new DirectoryInfo(TbRelease.Text);
                SortedList<string, FileInfo> nameFileInfoPairs = new SortedList<string, FileInfo>(new DuplicateKeyComparer<string>());

                foreach (FileInfo excelFile in releaseDir.EnumerateFiles("*.xls*", SearchOption.AllDirectories))
                {
                    nameFileInfoPairs.Add(excelFile.Name, excelFile);
                }

                foreach (FileInfo excelFile in nameFileInfoPairs.Values)
                {
                    LboxExcelFileList.Items.Add(excelFile);
                }
            }
            else
            {
                MessageBox.Show("Папка не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //компаратор нужен для того, чтобы в сортированный список можно было добавлять пары с одинаковыми ключами
        public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);

                if (result == 0)
                    return -1;   // обрабатываем равенство как "меньше", будет вставлять как в патче
                else
                    return result;
            }
        }

        private void BtDF_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(TbRelease.Text))
            {
                ExcelUtils.CreateDFRegistry(new DirectoryInfo(TbRelease.Text), LboxExcelFileList.SelectedItems.Cast<FileInfo>().ToList(), out List<FileInfo> patternMismatchFiles, true);
                if(patternMismatchFiles.Count > 0)
                {
                    string warningText =
                        "Количество столбцов не соответствует шаблону в файлах: " +
                        patternMismatchFiles
                        .Select(x => x.Name)
                        .Aggregate((x, y) => x + Environment.NewLine + y);

                    MessageBox.Show(warningText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Папка не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExcelUtils.excApp != null)
                try
                {
                    ExcelUtils.excApp.Quit();
                }
                catch { }
        }

        private void BtPPF_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(TbRelease.Text))
            {
                ExcelUtils.CreateDFRegistry(new DirectoryInfo(TbRelease.Text), LboxExcelFileList.SelectedItems.Cast<FileInfo>().ToList(), out List<FileInfo> patternMismatchFiles, false);
                if (patternMismatchFiles.Count > 0)
                {
                    string warningText =
                        "Количество столбцов не соответствует шаблону в файлах: " +
                        patternMismatchFiles
                        .Select(x => x.Name)
                        .Aggregate((x, y) => x + Environment.NewLine + y);

                    MessageBox.Show(warningText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Папка не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            LboxExcelFileList.Width = ClientSize.Width - 2 * 8;
            LboxExcelFileList.Height = ClientSize.Height - LboxExcelFileList.Top - BtDF.Height - 2 * 8;

            BtDF.Top = ClientSize.Height - BtDF.Height - 8;
            BtPPF.Top = ClientSize.Height - BtDF.Height - 8;

            TbRelease.Width = ClientSize.Width - TbRelease.Left - BtRelease.Width - 2 * 8;
            BtRelease.Left = ClientSize.Width - BtRelease.Width - 8;
        }
    }
}
