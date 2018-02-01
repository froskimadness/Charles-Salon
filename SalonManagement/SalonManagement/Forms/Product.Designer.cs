namespace SalonManagement.Forms
{
    partial class Product
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Product));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.stock = new DevExpress.XtraEditors.TextEdit();
            this.pname = new DevExpress.XtraEditors.TextEdit();
            this.price = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.mprice = new DevExpress.XtraLayout.LayoutControlItem();
            this.mpname = new DevExpress.XtraLayout.LayoutControlItem();
            this.mstock = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.price.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mprice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mstock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.stock);
            this.layoutControl1.Controls.Add(this.pname);
            this.layoutControl1.Controls.Add(this.price);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(284, 135);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(202, 84);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(70, 38);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // stock
            // 
            this.stock.Location = new System.Drawing.Point(86, 36);
            this.stock.Name = "stock";
            this.stock.Properties.Mask.EditMask = "n";
            this.stock.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.stock.Size = new System.Drawing.Size(186, 20);
            this.stock.StyleController = this.layoutControl1;
            this.stock.TabIndex = 6;
            // 
            // pname
            // 
            this.pname.Location = new System.Drawing.Point(86, 12);
            this.pname.Name = "pname";
            this.pname.Size = new System.Drawing.Size(186, 20);
            this.pname.StyleController = this.layoutControl1;
            this.pname.TabIndex = 5;
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(86, 60);
            this.price.Name = "price";
            this.price.Properties.Mask.EditMask = "n";
            this.price.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.price.Size = new System.Drawing.Size(186, 20);
            this.price.StyleController = this.layoutControl1;
            this.price.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.mprice,
            this.mpname,
            this.mstock,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(284, 135);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // mprice
            // 
            this.mprice.Control = this.price;
            this.mprice.CustomizationFormText = "Price:";
            this.mprice.Location = new System.Drawing.Point(0, 48);
            this.mprice.Name = "mprice";
            this.mprice.Size = new System.Drawing.Size(264, 24);
            this.mprice.Text = "Price:";
            this.mprice.TextSize = new System.Drawing.Size(71, 13);
            // 
            // mpname
            // 
            this.mpname.Control = this.pname;
            this.mpname.CustomizationFormText = "Product Name:";
            this.mpname.Location = new System.Drawing.Point(0, 0);
            this.mpname.Name = "mpname";
            this.mpname.Size = new System.Drawing.Size(264, 24);
            this.mpname.Text = "Product Name:";
            this.mpname.TextSize = new System.Drawing.Size(71, 13);
            // 
            // mstock
            // 
            this.mstock.Control = this.stock;
            this.mstock.CustomizationFormText = "Stock:";
            this.mstock.Location = new System.Drawing.Point(0, 24);
            this.mstock.Name = "mstock";
            this.mstock.Size = new System.Drawing.Size(264, 24);
            this.mstock.Text = "Stock:";
            this.mstock.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButton1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(190, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(74, 43);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(190, 43);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(132, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(132, 194);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 135);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Product";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.price.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mprice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mstock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit stock;
        private DevExpress.XtraEditors.TextEdit pname;
        private DevExpress.XtraEditors.TextEdit price;
        private DevExpress.XtraLayout.LayoutControlItem mprice;
        private DevExpress.XtraLayout.LayoutControlItem mpname;
        private DevExpress.XtraLayout.LayoutControlItem mstock;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}