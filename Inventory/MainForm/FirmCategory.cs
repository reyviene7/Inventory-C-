using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Inventory.Config;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using Query = ServeAll.Core.Queries.Query;


namespace Inventory.MainForm
{
    public partial class FirmCategory : Form
    {
        private FirmMain _main;
        private bool _add, _edt, _del, _img, _cat;
        private readonly int _userId;
        private readonly int _userTyp;
        private IEnumerable<ViewCategory> listCategory;
        private string _title, _type, _location, _code;
        private int _imgHeight, _imgWidth;

        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FirmCategory(int userId, int userTy)
        {
            _userId = userId;
            _userTyp = userTy;

            if (_userTyp != 1)
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);

                this.DialogResult = DialogResult.Cancel;
                return;
            }
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            bindRefreshed();
            _cat = true;
        }
        private void Options_Tick(object sender, EventArgs e)
        {
            PanelInterface.OptionTick(this, pnlOptions);
        }

        private void RightOptions_Tick(object sender, EventArgs e)
        {
            PanelInterface.RightOptionTick(this, pnlRightOptions);
        }

        private void FrmCategory_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInterface.MouseMOve(this, pnlRightOptions, e);
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            var que = PopupNotification.PopUpMassageLogOff();
            if (que <= 0) return;
            var log = new FirmLogin();
            log.Show();
            Close();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();
        }

        private void ButtonAdd()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = false;
            bntDelete.Enabled = false;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonUpd()
        {
            bntAdd.Enabled = false;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = false;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonDel()
        {
            bntAdd.Enabled = false;
            bntUpdate.Enabled = false;
            bntDelete.Enabled = true;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonSav()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = true;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonClr()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = false;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonCan()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = true;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }

        private void InputWhit()
        {
            txtCategoryId.BackColor = Color.White;
            txtCategoryCode.BackColor = Color.White;
            txtCategoryDetails.BackColor = Color.White;
            dkpDateRegister.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtCategoryId.Enabled = false;
            txtCategoryCode.Enabled = true;
            txtCategoryDetails.Enabled = true;
            dkpDateRegister.Enabled = true;
        }
        private void InputDisb()
        {
            txtCategoryId.Enabled = false;
            txtCategoryCode.Enabled = false;
            txtCategoryDetails.Enabled = false;
            dkpDateRegister.Enabled = false;
        }
        private void InputClea()
        {
            txtCategoryId.Clear();
            if (!_add == false)
            {
                txtCategoryCode.Clear();
            }
           
            txtCategoryDetails.Clear();
        }
        private void InputDimG()
        {
            txtCategoryId.BackColor = Color.DimGray;
            txtCategoryCode.BackColor = Color.DimGray;
            txtCategoryDetails.BackColor = Color.DimGray;
            dkpDateRegister.BackColor = Color.DimGray;
        }

        private void GenerateCode()
        {
            var lastCategoryId = FetchUtils.getLastCategoryId();
            var alphaNumeric = new GenerateAlpaNum("CAT", 3, lastCategoryId);
            alphaNumeric.Increment();
            txtCategoryCode.Text = alphaNumeric.ToString();
        }

        private void ButAdd()
        {
            ButtonAdd();
            _add = true;
            _edt = false;
            _del = false;
            gridControl.Enabled = false;
            if (_cat && _img == false)
            {
               
                InputEnab();
                InputWhit();
                InputClea();
                txtCategoryDetails.Focus();
                GenerateCode();
            }
        }
        private void ButUpd()
        {
            ButtonUpd();
            _add = false;
            _edt = true;
            _del = false;
            if (_cat && _img == false)
            {
                InputEnab();
                InputWhit();
                gridControl.Enabled = false;
            }
        }
        private void ButDel()
        {
            ButtonDel();
            InputDisb();
            InputWhit();
            _add = false;
            _edt = false;
            _del = true;
            gridControl.Enabled = false;
        }
        private void ButClr()
        {
            ButtonClr();
            InputWhit();
            InputDisb();
            gridControl.Enabled = true;
            txtCategoryCode.DataBindings.Clear();
            txtCategoryDetails.DataBindings.Clear();
        }
        private void ButSav()
        {
            if (_cat && _img == false)
            {
                SavCat();
            }
               
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gridControl.Enabled = true;
        }

        private void SavCat()
        {
            if (_add && _edt == false && _del == false && _img == false)
            {
                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                bindRefreshed();
            }
            if (_add == false && _edt && _del == false && _img == false)
            {
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                bindRefreshed();
            }
            if (_add == false && _edt == false && _del && _img == false)
            {
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                bindRefreshed();
            }
            _add = false;
            _edt = false;
            _del = false;
            _cat = true;
            _img = false;
            gridControl.Enabled = true;
            bindRefreshed();
        }

        private void bindRefreshed()
        {
            listCategory = EnumerableUtils.getCategoryList();
            BindCategoryList();
        }

        private void BindCategoryList()
        {
            gridControl.Update();
            try
            {
                var listCat = listCategory.Select(x => new {
                    Id = x.category_id,
                    CategoryCode = x.category_code,
                    Category = x.category_details,
                    DateRegister = x.date_register
                });

                gridControl.DataBindings.Clear();
                gridControl.DataSource = listCat;
                gridCategory.Columns[0].Width = 40;
                gridCategory.Columns[1].Width = 90;
                gridCategory.Columns[2].Width = 250;
                gridCategory.Columns[3].Width = 100;
            }
            catch (Exception ex)
            {
                gridControl.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }

        private void dkpREG_Leave(object sender, EventArgs e)
        {
            InputManipulation.InputBoxLeave(dkpDateRegister, bntSave, "Image Register", Messages.TitleCategory);
        }

        private void dkpREG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpDateRegister, bntSave, "Image Register", Messages.TitleCategory);
            }
        }

        private ViewCategory searchCategoryId(int id)
        {
            return listCategory.FirstOrDefault(view_category => view_category.category_id == id);
        }

        private void gridCategory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridCategory.RowCount > 0)
            {
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (id.Length > 0)
                    {
                        var category_id = int.Parse(id);
                        var category = searchCategoryId(category_id);
                        var categoryCode = category.category_code;
                        int categoryId = category.category_id;
                        txtCategoryId.Text = categoryId.ToString();
                        txtCategoryCode.Text = categoryCode;
                        txtCategoryDetails.Text = category.category_details;
                        dkpDateRegister.Value = category.date_register;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void gridCategory_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhit();
        }

        private void gridCategory_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            ButAdd();
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {
            ButUpd();
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            ButSav();
        }

        private void TxtCategoryDetails_KeyDown_1(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtCategoryDetails, dkpDateRegister, "Category Details", Messages.TitleCategory);
                }
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            ButCan();
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            ButClr();
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            if (_cat && _img == false)
            {
                InputWhit();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete Category Code: " + txtCategoryCode.Text.Trim(' ') + " " + "?", "Category Details");
                if (que)
                {
                    ButDel();
                    gridControl.Enabled = false;
                }
                else
                {
                    ButCan();
                    gridControl.Enabled = true;
                }
            }
        }

        private void bntHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }

        private void DataInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Category>(unWork);
                    var category = new Category()
                    {
                        category_code = txtCategoryCode.Text.Trim(' '),
                        category_details = txtCategoryDetails.Text.Trim(' '),
                        date_register = dkpDateRegister.Value.Date
                    };
                    var result = repository.Add(category);
                    if (result > 0)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Category Code: " +
                                                           txtCategoryCode.Text.Trim(' ')
                                                           + " " + Messages.SuccessInsert,
                            Messages.TitleSuccessInsert);
                        bindRefreshed();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFailedInsert);
                }
            }
        }

        private void DataUpdate()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var catId = Convert.ToInt32(txtCategoryId.Text);
                    var repository = new Repository<Category>(unWork);
                    var que = repository.Id(catId);

                    que.category_code = txtCategoryCode.Text.Trim(' ');
                    que.category_details = txtCategoryDetails.Text.Trim(' ');
                    que.date_register = dkpDateRegister.Value.Date;
                    var result = repository.Update(que);
                    if (result)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Category Code: " +
                                                           txtCategoryCode.Text.Trim(' ')
                                                           + " " + Messages.SuccessUpdate,
                            Messages.TitleSuccessUpdate);
                        bindRefreshed();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedUpdate);
                }
            }
        }
        private void DataDelete()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var catId = Convert.ToInt32(txtCategoryId.Text);
                    var repository = new Repository<Category>(unWork);
                    var que = repository.Id(catId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Category Code: " +
                                                           txtCategoryCode.Text.Trim(' ')
                                                           + " " + Messages.SuccessDelete,
                            Messages.TitleSuccessDelete);
                        bindRefreshed();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedDelete);
                }
            }
        }
    }
}
