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
        private bool _add, _edt, _del, _img, _cat, _sup;
        private readonly int _userId;
        private readonly int _userTyp;
        private IEnumerable<ViewCategory> listCategory;
        private IEnumerable<ViewSupplier> listSupplier;
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
            bindRefreshedCategory();
            bindRefreshedSupplier();
            XtraControl_SelectedPageChanged(xtraControl, null);
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
        private void InputWhitSup()
        {
            txtSupplierId.BackColor = Color.White;
            txtSupplierCode.BackColor = Color.White;
            txtSupplierName.BackColor = Color.White;
            cmbGender.BackColor = Color.White;
            cmbContact.BackColor = Color.White;
            cmbAddress.BackColor = Color.White;
            cmbCompany.BackColor = Color.White;
            dkpSupplier.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtCategoryId.Enabled = false;
            txtCategoryCode.Enabled = true;
            txtCategoryDetails.Enabled = true;
            dkpDateRegister.Enabled = true;
        }
        private void InputEnabSup()
        {
            txtSupplierId.Enabled = false;
            txtSupplierCode.Enabled = true;
            txtSupplierName.Enabled = true;
            cmbGender.Enabled = true;
            cmbContact.Enabled = true;
            cmbAddress.Enabled = true;
            cmbCompany.Enabled = true;
            dkpSupplier.Enabled = true;
        }
        private void InputDisb()
        {
            txtCategoryId.Enabled = false;
            txtCategoryCode.Enabled = false;
            txtCategoryDetails.Enabled = false;
            dkpDateRegister.Enabled = false;
        }
        private void InputDisbSup()
        {
            txtSupplierId.Enabled = false;
            txtSupplierCode.Enabled = false;
            txtSupplierName.Enabled = false;
            cmbGender.Enabled = false;
            cmbContact.Enabled = false;
            cmbAddress.Enabled = false;
            cmbCompany.Enabled = false;
            dkpSupplier.Enabled = false;
        }
        private void InputClea()
        {
            txtCategoryId.Clear();
            txtSupplierId.Clear();
            if (!_add == false)
            {
                txtCategoryCode.Clear();
                txtSupplierCode.Clear();
            }
            txtCategoryDetails.Clear();
            txtSupplierName.Clear();
            cmbGender.DataBindings.Clear();
            cmbContact.DataBindings.Clear();
            cmbAddress.DataBindings.Clear();
            cmbCompany.DataBindings.Clear();
        }
        private void InputDimG()
        {
            txtCategoryId.BackColor = Color.DimGray;
            txtCategoryCode.BackColor = Color.DimGray;
            txtCategoryDetails.BackColor = Color.DimGray;
            dkpDateRegister.BackColor = Color.DimGray;
        }
        private void InputDimGSup()
        {
            txtSupplierId.BackColor = Color.DimGray;
            txtSupplierCode.BackColor = Color.DimGray;
            txtSupplierName.BackColor = Color.DimGray;
            cmbGender.BackColor = Color.DimGray;
            cmbContact.BackColor = Color.DimGray;
            cmbAddress.BackColor = Color.DimGray;
            cmbCompany.BackColor = Color.DimGray;
            dkpSupplier.BackColor = Color.DimGray;
        }

        private void GenerateCode()
        {
            var lastCategoryId = FetchUtils.getLastCategoryId();
            var alphaNumeric = new GenerateAlpaNum("CAT", 3, lastCategoryId);
            alphaNumeric.Increment();
            txtCategoryCode.Text = alphaNumeric.ToString();
        }
        private void GenerateSupCode()
        {
            var lastSupplierId = FetchUtils.getLastSupplierId();
            var alphaNumeric = new GenerateAlpaNum("SUP", 3, lastSupplierId);
            alphaNumeric.Increment();
            txtSupplierCode.Text = alphaNumeric.ToString();
        }

        private void ButAdd()
        {
            ButtonAdd();
            _add = true;
            _edt = false;
            _del = false;
            gridControl.Enabled = false;
            if (_cat && _sup == false)
            {
                InputEnab();
                InputWhit();
                InputClea();
                txtCategoryDetails.Focus();
                GenerateCode();
            }
            if (_cat == false && _sup )
            {
                BindContact();
                BindCompany();
                BindAddress();
                InputEnabSup();
                InputWhitSup();
                InputClea();
                txtSupplierName.Focus();
                GenerateSupCode();
            }
        }
        private void ButUpd()
        {
            ButtonUpd();
            _add = false;
            _edt = true;
            _del = false;
            if (_cat && _sup == false)
            {
                InputEnab();
                InputWhit();
                gridControl.Enabled = false;
            } else if (_cat == false && _sup)
            {
                InputEnabSup();
                InputWhitSup();
                gridControl.Enabled = false;
            }
        }
        private void ButDel()
        {
            ButtonDel();
            InputDisb();
            InputWhit();
            InputWhitSup();
            InputDisbSup();
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
            InputWhitSup();
            InputDisbSup();
            gridControl.Enabled = true;
            txtCategoryCode.DataBindings.Clear();
            txtCategoryDetails.DataBindings.Clear();
            txtSupplierCode.DataBindings.Clear();
            txtSupplierName.DataBindings.Clear();
        }
        private void ButSav()
        {
            SavCat();
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            InputDisbSup();
            InputDimGSup();
            gridControl.Enabled = true;
        }

        private void SavCat()
        {
            if (_add && _edt == false && _del == false && _sup == false)
            {
                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                bindRefreshedCategory();
            }
            if (_add == false && _edt && _del == false && _sup == false)
            {
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                bindRefreshedCategory();
            }
            if (_add == false && _edt == false && _del && _sup == false)
            {
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                bindRefreshedCategory();
            }
            if (_add && _edt == false && _del == false && _cat == false)
            {
                DataInsertSup();
                ButtonSav();
                InputDisbSup();
                InputDimGSup();
                InputClea();
                bindRefreshedSupplier();
            }
            if (_add == false && _edt && _del == false && _cat == false)
            {
                DataUpdateSup();
                ButtonSav();
                InputDisbSup();
                InputDimGSup();
                InputClea();
                bindRefreshedSupplier();
            }
            if (_add == false && _edt == false && _del && _cat == false)
            {
                DataDeleteSup();
                ButtonSav();
                InputDisbSup();
                InputDimGSup();
                InputClea();
                bindRefreshedSupplier();
            }
            _add = false;
            _edt = false;
            _del = false;
            gridControl.Enabled = true;
            bindRefreshedCategory();
            bindRefreshedSupplier();
        }

        private void bindRefreshedCategory()
        {
            listCategory = EnumerableUtils.getCategoryList();
            BindCategoryList();
        }
        private void bindRefreshedSupplier()
        {
            listSupplier = EnumerableUtils.getSupplierList();
            BindSupplierList();
            BindCompany();
            BindContact();
            BindAddress();
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
        private void BindSupplierList()
        {
            gridCtrlSupplier.Update();
            try
            {
                var listCat = listSupplier.Select(x => new {
                    Id = x.supplier_id,
                    Code = x.supplier_code,
                    SupplierName = x.supplier_name,
                    Company = x.company_name,
                    Email = x.email_address,
                    Gender = x.gender,
                    Telephone = x.telephone_number,
                    Mobile = x.mobile_number,
                    Barangay = x.barangay,
                    Street = x.street,
                    Province = x.province,
                    DateRegister = x.date_register
                });

                gridCtrlSupplier.DataBindings.Clear();
                gridCtrlSupplier.DataSource = listCat;
                gridSupplier.Columns[0].Width = 40;
                gridSupplier.Columns[1].Width = 90;
                gridSupplier.Columns[2].Width = 250;
                gridSupplier.Columns[3].Width = 100;
                gridSupplier.Columns[4].Width = 100;
                gridSupplier.Columns[5].Width = 90;
                gridSupplier.Columns[6].Width = 100;
                gridSupplier.Columns[7].Width = 100;
                gridSupplier.Columns[8].Width = 100;
                gridSupplier.Columns[9].Width = 100;
                gridSupplier.Columns[10].Width = 100;
                gridSupplier.Columns[11].Width = 100;

            }
            catch (Exception ex)
            {
                gridControl.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
        private void BindContact()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Contact>(unWork);
                var query = repository.SelectAll(Query.AllContact).Select(x => x.mobile_number).Distinct().ToList();
                cmbContact.DataBindings.Clear();
                cmbContact.DataSource = query;
            }
        }

        private void BindAddress()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Address>(unWork);
                var query = repository.SelectAll(Query.AllAddress)
                            .Select(x => $"{x.street}, {x.barangay}, {x.city}, {x.province}")
                            .Distinct()
                            .OrderBy(addr => addr)
                            .ToList();
                cmbAddress.DataBindings.Clear();
                cmbAddress.DataSource = query;
            }
        }

        private void BindCompany()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Company>(unWork);
                var query = repository.SelectAll(Query.AllCompany).Select(x => x.company_name).Distinct().ToList();
                cmbCompany.DataBindings.Clear();
                cmbCompany.DataSource = query;
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
        private ViewSupplier searchSupplierId(int id)
        {
            return listSupplier.FirstOrDefault(view_supplier => view_supplier.supplier_id == id);
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

        private void GridSupplier_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridSupplier.RowCount > 0)
            {
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (id.Length > 0)
                    {
                        var supplier_id = int.Parse(id);
                        var supplier = searchSupplierId(supplier_id);
                        var supplierCode = supplier.supplier_code;
                        int supplierId = supplier.supplier_id;
                        txtSupplierId.Text = supplierId.ToString();
                        txtSupplierCode.Text = supplierCode;
                        txtSupplierName.Text = supplier.supplier_name;
                        cmbGender.Text = supplier.gender;
                        cmbContact.Text = supplier.mobile_number;
                        string fullAddress = $"{supplier.street}, {supplier.barangay}, {supplier.zip_code}, {supplier.province}";
                        cmbAddress.Text = fullAddress;
                        cmbCompany.Text = supplier.company_name;
                        dkpDateRegister.Value = supplier.date_register;
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
        private void GridSupplier_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhitSup();
        }

        private void GridSupplier_LostFocus(object sender, EventArgs e)
        {
            InputDimGSup();
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

        private void XtraControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraControl.SelectedTabPage == xtraCategory)
            {
                _cat = true;
                _sup = false;
                lblMainTitle.Text = "Category";
            }
            else if (xtraControl.SelectedTabPage == xtraSupplierTab)
            {
                _sup = true;
                _cat = false;
                lblMainTitle.Text = "Supplier";
            }
        }

        private void CmbContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindContact();
            }
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbContact, cmbAddress, "Supplier Contact",
                Messages.TitleSupplier);
            }
        }

        private void CmbAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindAddress();
            }
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbAddress, cmbCompany, "Supplier Address",
                Messages.TitleSupplier);
            }
        }

        private void CmbCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindCompany();
            }
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbCompany, dkpSupplier, "Supplier Company",
                Messages.TitleSupplier);
            }
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

        private void TxtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtSupplierName, cmbGender, "Supplier Name",
                Messages.TitleSupplier);
            }
        }

        private void CmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(cmbGender, cmbContact, "Supplier Name",
                Messages.TitleSupplier);
            }
        }

        private void DkpSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(dkpSupplier, bntSave, "Supplier Date",
                Messages.TitleSupplier);
            }
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            ButClr();
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            if (_cat && _sup == false)
            {
                InputWhit();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete Category: " + txtCategoryDetails.Text.Trim(' ') + " " + "?", "Category Details");
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
            if (_cat == false && _sup )
            {
                InputWhitSup();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete Supplier: " + txtSupplierName.Text.Trim(' ') + " " + "?", "Supplier Details");
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
                        bindRefreshedCategory();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFailedInsert);
                }
            }
        }
        private void DataInsertSup()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Supplier>(unWork);
                    var supplier = new Supplier()
                    {
                        supplier_code = txtSupplierCode.Text.Trim(' '),
                        supplier_name = txtSupplierName.Text.Trim(' '),
                        gender = cmbGender.Text.Trim(' '),
                        contact_id = FetchUtils.getContactId(cmbContact.Text),
                        address_id = FetchUtils.getAddressId(cmbAddress.Text),
                        company_id = FetchUtils.getCompanyId(cmbCompany.Text),
                        date_register = dkpSupplier.Value.Date
                    };
                    var result = repository.Add(supplier);
                    if (result > 0)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Supplier: " +
                                                           txtSupplierName.Text.Trim(' ')
                                                           + " " + Messages.SuccessInsert,
                            Messages.TitleSuccessInsert);
                        bindRefreshedSupplier();
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
                        bindRefreshedCategory();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedUpdate);
                }
            }
        }

        private void DataUpdateSup()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    // Validate and parse supplier ID
                    if (!int.TryParse(txtSupplierId.Text, out int supplierId) || supplierId <= 0)
                    {
                        PopupNotification.PopUpMessages(0, "Invalid supplier ID.", Messages.TitleFialedUpdate);
                        return;
                    }

                    // Initialize repository and fetch supplier
                    var repository = new Repository<Supplier>(unWork);
                    var supplier = repository.Id(supplierId);
                    if (supplier == null)
                    {
                        PopupNotification.PopUpMessages(0, "Supplier not found.", Messages.TitleFialedUpdate);
                        return;
                    }

                    // Fetch and validate foreign key IDs, use existing values if invalid
                    int contactId = FetchUtils.getContactId(cmbContact.Text);
                    if (contactId <= 0) contactId = supplier.contact_id; // Retain existing if invalid

                    int addressId = FetchUtils.getAddressId(cmbAddress.Text);
                    if (addressId <= 0) addressId = supplier.address_id; // Retain existing if invalid

                    int companyId = FetchUtils.getCompanyId(cmbCompany.Text);
                    if (companyId <= 0) companyId = supplier.company_id; // Retain existing if invalid

                    // Update supplier properties with new or existing values
                    supplier.supplier_code = string.IsNullOrWhiteSpace(txtSupplierCode.Text.Trim()) ? supplier.supplier_code : txtSupplierCode.Text.Trim();
                    supplier.supplier_name = string.IsNullOrWhiteSpace(txtSupplierName.Text.Trim()) ? supplier.supplier_name : txtSupplierName.Text.Trim();
                    supplier.gender = string.IsNullOrWhiteSpace(cmbGender.Text.Trim()) ? supplier.gender : cmbGender.Text.Trim();
                    supplier.contact_id = contactId;
                    supplier.address_id = addressId;
                    supplier.company_id = companyId;
                    supplier.date_register = dkpSupplier.Checked ? dkpSupplier.Value.Date : supplier.date_register;

                    // Perform update
                    var result = repository.Update(supplier);
                    if (result)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, $"Supplier: {supplier.supplier_name} {Messages.SuccessUpdate}",
                            Messages.TitleSuccessUpdate);
                        bindRefreshedSupplier();
                    }
                    else
                    {
                        unWork.Rollback();
                        PopupNotification.PopUpMessages(0, "Update failed. Please check the input.", Messages.TitleFialedUpdate);
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, $"Update failed due to an error: {ex.Message}", Messages.TitleFialedUpdate);
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
                        bindRefreshedCategory();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedDelete);
                }
            }
        }
        private void DataDeleteSup()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var supplierId = Convert.ToInt32(txtSupplierId.Text); // You must have supplier_id in a hidden/visible field
                    var repository = new Repository<Supplier>(unWork);
                    var supplier = repository.Id(supplierId);

                    if (supplier != null)
                    {
                        var result = repository.Delete(supplier);
                        if (result)
                        {
                            unWork.Commit();
                            PopupNotification.PopUpMessages(1, "Supplier: " +
                                                               txtSupplierName.Text.Trim(' ')
                                                               + " " + Messages.SuccessDelete,
                                Messages.TitleSuccessDelete);
                            bindRefreshedSupplier();
                        }
                    }
                    else
                    {
                        PopupNotification.PopUpMessages(0, "Supplier not found.", Messages.TitleFialedDelete);
                        unWork.Rollback();
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
