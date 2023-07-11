/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/07/2018
 * Time: 23:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.filetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cropslistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manufacturerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.cropsvarietiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cropsdiseaseslistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pestInsecticideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.datastoreconfigmanagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helptoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.abouttoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.hometoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.lbldatetime = new System.Windows.Forms.ToolStripStatusLabel();
			this.lbltimelapsed = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripSplitButtoncheckdbconnections = new System.Windows.Forms.ToolStripSplitButton();
			this.postgresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createPostgresqlDatastoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.checkpostgresqlconnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.updatepostgresqldbscemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.sqliteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createSqliteDatastoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.checksqliteconnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.updatesqlitedbschemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mysqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createMysqlDatastoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.checkmysqlconnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.updatemysqldbschemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.mssqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createMssqlDatastoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.checkmssqlconnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.updatemssqldbschemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.datastoreconfigmanagerutilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btndatabaseutils = new System.Windows.Forms.Button();
			this.btncategorieslist = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btncropsvarietieslist = new System.Windows.Forms.Button();
			this.imgerror = new System.Windows.Forms.PictureBox();
			this.imgwarn = new System.Windows.Forms.PictureBox();
			this.imginfo = new System.Windows.Forms.PictureBox();
			this.btnexit = new System.Windows.Forms.Button();
			this.btnsearch = new System.Windows.Forms.Button();
			this.btnsettingslist = new System.Windows.Forms.Button();
			this.btnmanufacturerslist = new System.Windows.Forms.Button();
			this.btnpestsinsecticideslist = new System.Windows.Forms.Button();
			this.btncropsdiseaseslist = new System.Windows.Forms.Button();
			this.btncropslist = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtlog = new System.Windows.Forms.TextBox();
			this.notifyIconntharene = new System.Windows.Forms.NotifyIcon(this.components);
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgerror)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgwarn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imginfo)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.filetoolStripMenuItem,
									this.helptoolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(664, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// filetoolStripMenuItem
			// 
			this.filetoolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.filetoolStripMenuItem.CheckOnClick = true;
			this.filetoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.cropslistToolStripMenuItem,
									this.manufacturerToolStripMenuItem,
									this.categoriesToolStripMenuItem,
									this.toolStripSeparator16,
									this.cropsvarietiesToolStripMenuItem,
									this.cropsdiseaseslistToolStripMenuItem,
									this.pestInsecticideToolStripMenuItem,
									this.toolStripSeparator17,
									this.settingsToolStripMenuItem,
									this.toolStripSeparator14,
									this.datastoreconfigmanagerToolStripMenuItem,
									this.toolStripSeparator1,
									this.searchToolStripMenuItem,
									this.toolStripSeparator18,
									this.exitToolStripMenuItem});
			this.filetoolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.filetoolStripMenuItem.Name = "filetoolStripMenuItem";
			this.filetoolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.filetoolStripMenuItem.Text = "File";
			// 
			// cropslistToolStripMenuItem
			// 
			this.cropslistToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.cropslistToolStripMenuItem.CheckOnClick = true;
			this.cropslistToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.cropslistToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cropslistToolStripMenuItem.Image")));
			this.cropslistToolStripMenuItem.Name = "cropslistToolStripMenuItem";
			this.cropslistToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.cropslistToolStripMenuItem.Text = "crops";
			this.cropslistToolStripMenuItem.Click += new System.EventHandler(this.lstcropToolStripMenuItemClick);
			// 
			// manufacturerToolStripMenuItem
			// 
			this.manufacturerToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.manufacturerToolStripMenuItem.CheckOnClick = true;
			this.manufacturerToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.manufacturerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manufacturerToolStripMenuItem.Image")));
			this.manufacturerToolStripMenuItem.Name = "manufacturerToolStripMenuItem";
			this.manufacturerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.manufacturerToolStripMenuItem.Text = "manufacturers";
			this.manufacturerToolStripMenuItem.Click += new System.EventHandler(this.ManufacturerToolStripMenuItemClick);
			// 
			// categoriesToolStripMenuItem
			// 
			this.categoriesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("categoriesToolStripMenuItem.Image")));
			this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
			this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.categoriesToolStripMenuItem.Text = "categories";
			this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.CategoriesToolStripMenuItemClick);
			// 
			// toolStripSeparator16
			// 
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(189, 6);
			// 
			// cropsvarietiesToolStripMenuItem
			// 
			this.cropsvarietiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cropsvarietiesToolStripMenuItem.Image")));
			this.cropsvarietiesToolStripMenuItem.Name = "cropsvarietiesToolStripMenuItem";
			this.cropsvarietiesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.cropsvarietiesToolStripMenuItem.Text = "crops varieties";
			this.cropsvarietiesToolStripMenuItem.Click += new System.EventHandler(this.CropsvarietiesToolStripMenuItemClick);
			// 
			// cropsdiseaseslistToolStripMenuItem
			// 
			this.cropsdiseaseslistToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.cropsdiseaseslistToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.cropsdiseaseslistToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cropsdiseaseslistToolStripMenuItem.Image")));
			this.cropsdiseaseslistToolStripMenuItem.Name = "cropsdiseaseslistToolStripMenuItem";
			this.cropsdiseaseslistToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.cropsdiseaseslistToolStripMenuItem.Text = "diseases/pests";
			this.cropsdiseaseslistToolStripMenuItem.Click += new System.EventHandler(this.CropsdiseaseslistToolStripMenuItemClick);
			// 
			// pestInsecticideToolStripMenuItem
			// 
			this.pestInsecticideToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.pestInsecticideToolStripMenuItem.CheckOnClick = true;
			this.pestInsecticideToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.pestInsecticideToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pestInsecticideToolStripMenuItem.Image")));
			this.pestInsecticideToolStripMenuItem.Name = "pestInsecticideToolStripMenuItem";
			this.pestInsecticideToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.pestInsecticideToolStripMenuItem.Text = "pesticides/insecticides";
			this.pestInsecticideToolStripMenuItem.Click += new System.EventHandler(this.PestInsecticideToolStripMenuItemClick);
			// 
			// toolStripSeparator17
			// 
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new System.Drawing.Size(189, 6);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.settingsToolStripMenuItem.CheckOnClick = true;
			this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.settingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsToolStripMenuItem.Image")));
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.settingsToolStripMenuItem.Text = "settings";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItemClick);
			// 
			// toolStripSeparator14
			// 
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(189, 6);
			// 
			// datastoreconfigmanagerToolStripMenuItem
			// 
			this.datastoreconfigmanagerToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.datastoreconfigmanagerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("datastoreconfigmanagerToolStripMenuItem.Image")));
			this.datastoreconfigmanagerToolStripMenuItem.Name = "datastoreconfigmanagerToolStripMenuItem";
			this.datastoreconfigmanagerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.datastoreconfigmanagerToolStripMenuItem.Text = "utils";
			this.datastoreconfigmanagerToolStripMenuItem.Click += new System.EventHandler(this.DatastoreconfigmanagerToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.searchToolStripMenuItem.Text = "search";
			this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItemClick);
			// 
			// toolStripSeparator18
			// 
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(189, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.exitToolStripMenuItem.CheckOnClick = true;
			this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.exitToolStripMenuItem.Text = "exit";
			this.exitToolStripMenuItem.ToolTipText = "exit the app";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// helptoolStripMenuItem
			// 
			this.helptoolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.helptoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.abouttoolStripMenuItem,
									this.toolStripSeparator2,
									this.hometoolStripMenuItem});
			this.helptoolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.helptoolStripMenuItem.Name = "helptoolStripMenuItem";
			this.helptoolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helptoolStripMenuItem.Text = "Help";
			// 
			// abouttoolStripMenuItem
			// 
			this.abouttoolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.abouttoolStripMenuItem.CheckOnClick = true;
			this.abouttoolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.abouttoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abouttoolStripMenuItem.Image")));
			this.abouttoolStripMenuItem.Name = "abouttoolStripMenuItem";
			this.abouttoolStripMenuItem.Size = new System.Drawing.Size(105, 22);
			this.abouttoolStripMenuItem.Text = "about";
			this.abouttoolStripMenuItem.Click += new System.EventHandler(this.AbouttoolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(102, 6);
			// 
			// hometoolStripMenuItem
			// 
			this.hometoolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.hometoolStripMenuItem.CheckOnClick = true;
			this.hometoolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.hometoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hometoolStripMenuItem.Image")));
			this.hometoolStripMenuItem.Name = "hometoolStripMenuItem";
			this.hometoolStripMenuItem.Size = new System.Drawing.Size(105, 22);
			this.hometoolStripMenuItem.Text = "help";
			this.hometoolStripMenuItem.Click += new System.EventHandler(this.HometoolStripMenuItemClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripProgressBar,
									this.lbldatetime,
									this.lbltimelapsed,
									this.toolStripSplitButtoncheckdbconnections});
			this.statusStrip1.Location = new System.Drawing.Point(0, 515);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(664, 26);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.BackColor = System.Drawing.Color.Black;
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new System.Drawing.Size(150, 20);
			this.toolStripProgressBar.Step = 1;
			this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// lbldatetime
			// 
			this.lbldatetime.Name = "lbldatetime";
			this.lbldatetime.Size = new System.Drawing.Size(0, 21);
			// 
			// lbltimelapsed
			// 
			this.lbltimelapsed.Name = "lbltimelapsed";
			this.lbltimelapsed.Size = new System.Drawing.Size(0, 21);
			// 
			// toolStripSplitButtoncheckdbconnections
			// 
			this.toolStripSplitButtoncheckdbconnections.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.postgresToolStripMenuItem,
									this.toolStripSeparator4,
									this.sqliteToolStripMenuItem,
									this.toolStripSeparator3,
									this.mysqlToolStripMenuItem,
									this.toolStripSeparator5,
									this.mssqlToolStripMenuItem,
									this.toolStripSeparator15,
									this.datastoreconfigmanagerutilsToolStripMenuItem});
			this.toolStripSplitButtoncheckdbconnections.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButtoncheckdbconnections.Image")));
			this.toolStripSplitButtoncheckdbconnections.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButtoncheckdbconnections.Name = "toolStripSplitButtoncheckdbconnections";
			this.toolStripSplitButtoncheckdbconnections.Size = new System.Drawing.Size(138, 24);
			this.toolStripSplitButtoncheckdbconnections.Text = "check connections";
			this.toolStripSplitButtoncheckdbconnections.Visible = false;
			this.toolStripSplitButtoncheckdbconnections.ButtonClick += new System.EventHandler(this.ToolStripSplitButtoncheckdbconnectionsButtonClick);
			// 
			// postgresToolStripMenuItem
			// 
			this.postgresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.createPostgresqlDatastoreToolStripMenuItem,
									this.toolStripSeparator6,
									this.checkpostgresqlconnectionToolStripMenuItem,
									this.toolStripSeparator10,
									this.updatepostgresqldbscemaToolStripMenuItem});
			this.postgresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("postgresToolStripMenuItem.Image")));
			this.postgresToolStripMenuItem.Name = "postgresToolStripMenuItem";
			this.postgresToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.postgresToolStripMenuItem.Text = "postgresql";
			this.postgresToolStripMenuItem.Click += new System.EventHandler(this.PostgresToolStripMenuItemClick);
			// 
			// createPostgresqlDatastoreToolStripMenuItem
			// 
			this.createPostgresqlDatastoreToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createPostgresqlDatastoreToolStripMenuItem.Image")));
			this.createPostgresqlDatastoreToolStripMenuItem.Name = "createPostgresqlDatastoreToolStripMenuItem";
			this.createPostgresqlDatastoreToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
			this.createPostgresqlDatastoreToolStripMenuItem.Text = "create postgresql datastore";
			this.createPostgresqlDatastoreToolStripMenuItem.Click += new System.EventHandler(this.CreatePostgresqlDatastoreToolStripMenuItemClick);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(223, 6);
			// 
			// checkpostgresqlconnectionToolStripMenuItem
			// 
			this.checkpostgresqlconnectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkpostgresqlconnectionToolStripMenuItem.Image")));
			this.checkpostgresqlconnectionToolStripMenuItem.Name = "checkpostgresqlconnectionToolStripMenuItem";
			this.checkpostgresqlconnectionToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
			this.checkpostgresqlconnectionToolStripMenuItem.Text = "check postgresql connection";
			this.checkpostgresqlconnectionToolStripMenuItem.Click += new System.EventHandler(this.CheckpostgresqlconnectionToolStripMenuItemClick);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(223, 6);
			// 
			// updatepostgresqldbscemaToolStripMenuItem
			// 
			this.updatepostgresqldbscemaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updatepostgresqldbscemaToolStripMenuItem.Image")));
			this.updatepostgresqldbscemaToolStripMenuItem.Name = "updatepostgresqldbscemaToolStripMenuItem";
			this.updatepostgresqldbscemaToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
			this.updatepostgresqldbscemaToolStripMenuItem.Text = "update postgresql db scema";
			this.updatepostgresqldbscemaToolStripMenuItem.Click += new System.EventHandler(this.UpdatepostgresqldbscemaToolStripMenuItemClick);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(207, 6);
			// 
			// sqliteToolStripMenuItem
			// 
			this.sqliteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.createSqliteDatastoreToolStripMenuItem,
									this.toolStripSeparator7,
									this.checksqliteconnectionToolStripMenuItem,
									this.toolStripSeparator11,
									this.updatesqlitedbschemaToolStripMenuItem});
			this.sqliteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sqliteToolStripMenuItem.Image")));
			this.sqliteToolStripMenuItem.Name = "sqliteToolStripMenuItem";
			this.sqliteToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.sqliteToolStripMenuItem.Text = "sqlite";
			this.sqliteToolStripMenuItem.Click += new System.EventHandler(this.SqliteToolStripMenuItemClick);
			// 
			// createSqliteDatastoreToolStripMenuItem
			// 
			this.createSqliteDatastoreToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createSqliteDatastoreToolStripMenuItem.Image")));
			this.createSqliteDatastoreToolStripMenuItem.Name = "createSqliteDatastoreToolStripMenuItem";
			this.createSqliteDatastoreToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.createSqliteDatastoreToolStripMenuItem.Text = "create sqlite datastore";
			this.createSqliteDatastoreToolStripMenuItem.Click += new System.EventHandler(this.CreateSqliteDatastoreToolStripMenuItemClick);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(200, 6);
			// 
			// checksqliteconnectionToolStripMenuItem
			// 
			this.checksqliteconnectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checksqliteconnectionToolStripMenuItem.Image")));
			this.checksqliteconnectionToolStripMenuItem.Name = "checksqliteconnectionToolStripMenuItem";
			this.checksqliteconnectionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.checksqliteconnectionToolStripMenuItem.Text = "check sqlite connection";
			this.checksqliteconnectionToolStripMenuItem.Click += new System.EventHandler(this.ChecksqliteconnectionToolStripMenuItemClick);
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(200, 6);
			// 
			// updatesqlitedbschemaToolStripMenuItem
			// 
			this.updatesqlitedbschemaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updatesqlitedbschemaToolStripMenuItem.Image")));
			this.updatesqlitedbschemaToolStripMenuItem.Name = "updatesqlitedbschemaToolStripMenuItem";
			this.updatesqlitedbschemaToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.updatesqlitedbschemaToolStripMenuItem.Text = "update sqlite db schema";
			this.updatesqlitedbschemaToolStripMenuItem.Click += new System.EventHandler(this.UpdatesqlitedbschemaToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(207, 6);
			// 
			// mysqlToolStripMenuItem
			// 
			this.mysqlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.createMysqlDatastoreToolStripMenuItem,
									this.toolStripSeparator8,
									this.checkmysqlconnectionToolStripMenuItem,
									this.toolStripSeparator12,
									this.updatemysqldbschemaToolStripMenuItem});
			this.mysqlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mysqlToolStripMenuItem.Image")));
			this.mysqlToolStripMenuItem.Name = "mysqlToolStripMenuItem";
			this.mysqlToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.mysqlToolStripMenuItem.Text = "mysql";
			this.mysqlToolStripMenuItem.Click += new System.EventHandler(this.MysqlToolStripMenuItemClick);
			// 
			// createMysqlDatastoreToolStripMenuItem
			// 
			this.createMysqlDatastoreToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createMysqlDatastoreToolStripMenuItem.Image")));
			this.createMysqlDatastoreToolStripMenuItem.Name = "createMysqlDatastoreToolStripMenuItem";
			this.createMysqlDatastoreToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.createMysqlDatastoreToolStripMenuItem.Text = "create mysql datastore";
			this.createMysqlDatastoreToolStripMenuItem.Click += new System.EventHandler(this.CreateMysqlDatastoreToolStripMenuItemClick);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(204, 6);
			// 
			// checkmysqlconnectionToolStripMenuItem
			// 
			this.checkmysqlconnectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkmysqlconnectionToolStripMenuItem.Image")));
			this.checkmysqlconnectionToolStripMenuItem.Name = "checkmysqlconnectionToolStripMenuItem";
			this.checkmysqlconnectionToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.checkmysqlconnectionToolStripMenuItem.Text = "check mysql connection";
			this.checkmysqlconnectionToolStripMenuItem.Click += new System.EventHandler(this.CheckmysqlconnectionToolStripMenuItemClick);
			// 
			// toolStripSeparator12
			// 
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(204, 6);
			// 
			// updatemysqldbschemaToolStripMenuItem
			// 
			this.updatemysqldbschemaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updatemysqldbschemaToolStripMenuItem.Image")));
			this.updatemysqldbschemaToolStripMenuItem.Name = "updatemysqldbschemaToolStripMenuItem";
			this.updatemysqldbschemaToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.updatemysqldbschemaToolStripMenuItem.Text = "update mysql db schema";
			this.updatemysqldbschemaToolStripMenuItem.Click += new System.EventHandler(this.UpdatemysqldbschemaToolStripMenuItemClick);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(207, 6);
			// 
			// mssqlToolStripMenuItem
			// 
			this.mssqlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.createMssqlDatastoreToolStripMenuItem,
									this.toolStripSeparator9,
									this.checkmssqlconnectionToolStripMenuItem,
									this.toolStripSeparator13,
									this.updatemssqldbschemaToolStripMenuItem});
			this.mssqlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mssqlToolStripMenuItem.Image")));
			this.mssqlToolStripMenuItem.Name = "mssqlToolStripMenuItem";
			this.mssqlToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.mssqlToolStripMenuItem.Text = "mssql";
			this.mssqlToolStripMenuItem.Click += new System.EventHandler(this.MssqlToolStripMenuItemClick);
			// 
			// createMssqlDatastoreToolStripMenuItem
			// 
			this.createMssqlDatastoreToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createMssqlDatastoreToolStripMenuItem.Image")));
			this.createMssqlDatastoreToolStripMenuItem.Name = "createMssqlDatastoreToolStripMenuItem";
			this.createMssqlDatastoreToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.createMssqlDatastoreToolStripMenuItem.Text = "create mssql datastore";
			this.createMssqlDatastoreToolStripMenuItem.Click += new System.EventHandler(this.CreateMssqlDatastoreToolStripMenuItemClick);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(203, 6);
			// 
			// checkmssqlconnectionToolStripMenuItem
			// 
			this.checkmssqlconnectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("checkmssqlconnectionToolStripMenuItem.Image")));
			this.checkmssqlconnectionToolStripMenuItem.Name = "checkmssqlconnectionToolStripMenuItem";
			this.checkmssqlconnectionToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.checkmssqlconnectionToolStripMenuItem.Text = "check mssql connection";
			this.checkmssqlconnectionToolStripMenuItem.Click += new System.EventHandler(this.CheckmssqlconnectionToolStripMenuItemClick);
			// 
			// toolStripSeparator13
			// 
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(203, 6);
			// 
			// updatemssqldbschemaToolStripMenuItem
			// 
			this.updatemssqldbschemaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updatemssqldbschemaToolStripMenuItem.Image")));
			this.updatemssqldbschemaToolStripMenuItem.Name = "updatemssqldbschemaToolStripMenuItem";
			this.updatemssqldbschemaToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			this.updatemssqldbschemaToolStripMenuItem.Text = "update mssql db schema";
			this.updatemssqldbschemaToolStripMenuItem.Click += new System.EventHandler(this.UpdatemssqldbschemaToolStripMenuItemClick);
			// 
			// toolStripSeparator15
			// 
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(207, 6);
			// 
			// datastoreconfigmanagerutilsToolStripMenuItem
			// 
			this.datastoreconfigmanagerutilsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("datastoreconfigmanagerutilsToolStripMenuItem.Image")));
			this.datastoreconfigmanagerutilsToolStripMenuItem.Name = "datastoreconfigmanagerutilsToolStripMenuItem";
			this.datastoreconfigmanagerutilsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.datastoreconfigmanagerutilsToolStripMenuItem.Text = "datastore config manager";
			this.datastoreconfigmanagerutilsToolStripMenuItem.Click += new System.EventHandler(this.DatastoreconfigmanagerutilsToolStripMenuItemClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
			this.splitContainer1.Panel1.Controls.Add(this.btndatabaseutils);
			this.splitContainer1.Panel1.Controls.Add(this.btncategorieslist);
			this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
			this.splitContainer1.Panel1.Controls.Add(this.btncropsvarietieslist);
			this.splitContainer1.Panel1.Controls.Add(this.imgerror);
			this.splitContainer1.Panel1.Controls.Add(this.imgwarn);
			this.splitContainer1.Panel1.Controls.Add(this.imginfo);
			this.splitContainer1.Panel1.Controls.Add(this.btnexit);
			this.splitContainer1.Panel1.Controls.Add(this.btnsearch);
			this.splitContainer1.Panel1.Controls.Add(this.btnsettingslist);
			this.splitContainer1.Panel1.Controls.Add(this.btnmanufacturerslist);
			this.splitContainer1.Panel1.Controls.Add(this.btnpestsinsecticideslist);
			this.splitContainer1.Panel1.Controls.Add(this.btncropsdiseaseslist);
			this.splitContainer1.Panel1.Controls.Add(this.btncropslist);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Size = new System.Drawing.Size(664, 491);
			this.splitContainer1.SplitterDistance = 227;
			this.splitContainer1.TabIndex = 2;
			// 
			// btndatabaseutils
			// 
			this.btndatabaseutils.BackColor = System.Drawing.SystemColors.Control;
			this.btndatabaseutils.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndatabaseutils.ForeColor = System.Drawing.Color.Black;
			this.btndatabaseutils.Image = ((System.Drawing.Image)(resources.GetObject("btndatabaseutils.Image")));
			this.btndatabaseutils.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btndatabaseutils.Location = new System.Drawing.Point(12, 337);
			this.btndatabaseutils.Name = "btndatabaseutils";
			this.btndatabaseutils.Size = new System.Drawing.Size(158, 42);
			this.btndatabaseutils.TabIndex = 8;
			this.btndatabaseutils.Text = "utils";
			this.btndatabaseutils.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btndatabaseutils.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btndatabaseutils.UseVisualStyleBackColor = false;
			this.btndatabaseutils.Click += new System.EventHandler(this.BtndatabaseutilsClick);
			// 
			// btncategorieslist
			// 
			this.btncategorieslist.BackColor = System.Drawing.SystemColors.Control;
			this.btncategorieslist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncategorieslist.ForeColor = System.Drawing.Color.Black;
			this.btncategorieslist.Image = ((System.Drawing.Image)(resources.GetObject("btncategorieslist.Image")));
			this.btncategorieslist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncategorieslist.Location = new System.Drawing.Point(14, 131);
			this.btncategorieslist.Name = "btncategorieslist";
			this.btncategorieslist.Size = new System.Drawing.Size(156, 31);
			this.btncategorieslist.TabIndex = 3;
			this.btncategorieslist.Text = "categories";
			this.btncategorieslist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncategorieslist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncategorieslist.UseVisualStyleBackColor = false;
			this.btncategorieslist.Click += new System.EventHandler(this.BtncategorieslistClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(143, 439);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(37, 27);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// btncropsvarietieslist
			// 
			this.btncropsvarietieslist.BackColor = System.Drawing.SystemColors.Control;
			this.btncropsvarietieslist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncropsvarietieslist.ForeColor = System.Drawing.Color.Black;
			this.btncropsvarietieslist.Image = ((System.Drawing.Image)(resources.GetObject("btncropsvarietieslist.Image")));
			this.btncropsvarietieslist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncropsvarietieslist.Location = new System.Drawing.Point(14, 167);
			this.btncropsvarietieslist.Name = "btncropsvarietieslist";
			this.btncropsvarietieslist.Size = new System.Drawing.Size(156, 37);
			this.btncropsvarietieslist.TabIndex = 4;
			this.btncropsvarietieslist.Text = "crops varieties";
			this.btncropsvarietieslist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncropsvarietieslist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncropsvarietieslist.UseVisualStyleBackColor = false;
			this.btncropsvarietieslist.Click += new System.EventHandler(this.BtncropsvarietieslistClick);
			// 
			// imgerror
			// 
			this.imgerror.Image = ((System.Drawing.Image)(resources.GetObject("imgerror.Image")));
			this.imgerror.Location = new System.Drawing.Point(100, 439);
			this.imgerror.Name = "imgerror";
			this.imgerror.Size = new System.Drawing.Size(37, 27);
			this.imgerror.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgerror.TabIndex = 8;
			this.imgerror.TabStop = false;
			// 
			// imgwarn
			// 
			this.imgwarn.Image = ((System.Drawing.Image)(resources.GetObject("imgwarn.Image")));
			this.imgwarn.Location = new System.Drawing.Point(57, 439);
			this.imgwarn.Name = "imgwarn";
			this.imgwarn.Size = new System.Drawing.Size(37, 27);
			this.imgwarn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgwarn.TabIndex = 7;
			this.imgwarn.TabStop = false;
			// 
			// imginfo
			// 
			this.imginfo.Image = ((System.Drawing.Image)(resources.GetObject("imginfo.Image")));
			this.imginfo.Location = new System.Drawing.Point(14, 439);
			this.imginfo.Name = "imginfo";
			this.imginfo.Size = new System.Drawing.Size(37, 27);
			this.imginfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imginfo.TabIndex = 1;
			this.imginfo.TabStop = false;
			// 
			// btnexit
			// 
			this.btnexit.BackColor = System.Drawing.SystemColors.Control;
			this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnexit.ForeColor = System.Drawing.Color.Black;
			this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
			this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnexit.Location = new System.Drawing.Point(12, 385);
			this.btnexit.Name = "btnexit";
			this.btnexit.Size = new System.Drawing.Size(156, 35);
			this.btnexit.TabIndex = 9;
			this.btnexit.Text = "exit";
			this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnexit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnexit.UseVisualStyleBackColor = false;
			this.btnexit.Click += new System.EventHandler(this.BtnexitClick);
			// 
			// btnsearch
			// 
			this.btnsearch.BackColor = System.Drawing.SystemColors.Control;
			this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnsearch.ForeColor = System.Drawing.Color.Black;
			this.btnsearch.Image = ((System.Drawing.Image)(resources.GetObject("btnsearch.Image")));
			this.btnsearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnsearch.Location = new System.Drawing.Point(14, 14);
			this.btnsearch.Name = "btnsearch";
			this.btnsearch.Size = new System.Drawing.Size(156, 35);
			this.btnsearch.TabIndex = 0;
			this.btnsearch.Text = "search";
			this.btnsearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnsearch.UseVisualStyleBackColor = false;
			this.btnsearch.Click += new System.EventHandler(this.BtnsearchClick);
			// 
			// btnsettingslist
			// 
			this.btnsettingslist.BackColor = System.Drawing.SystemColors.Control;
			this.btnsettingslist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnsettingslist.ForeColor = System.Drawing.Color.Black;
			this.btnsettingslist.Image = ((System.Drawing.Image)(resources.GetObject("btnsettingslist.Image")));
			this.btnsettingslist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnsettingslist.Location = new System.Drawing.Point(12, 299);
			this.btnsettingslist.Name = "btnsettingslist";
			this.btnsettingslist.Size = new System.Drawing.Size(158, 32);
			this.btnsettingslist.TabIndex = 7;
			this.btnsettingslist.Text = "settings";
			this.btnsettingslist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnsettingslist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnsettingslist.UseVisualStyleBackColor = false;
			this.btnsettingslist.Click += new System.EventHandler(this.BtnsettingsClick);
			// 
			// btnmanufacturerslist
			// 
			this.btnmanufacturerslist.BackColor = System.Drawing.SystemColors.Control;
			this.btnmanufacturerslist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnmanufacturerslist.ForeColor = System.Drawing.Color.Black;
			this.btnmanufacturerslist.Image = ((System.Drawing.Image)(resources.GetObject("btnmanufacturerslist.Image")));
			this.btnmanufacturerslist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnmanufacturerslist.Location = new System.Drawing.Point(12, 94);
			this.btnmanufacturerslist.Name = "btnmanufacturerslist";
			this.btnmanufacturerslist.Size = new System.Drawing.Size(158, 31);
			this.btnmanufacturerslist.TabIndex = 2;
			this.btnmanufacturerslist.Text = "manufacturers";
			this.btnmanufacturerslist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnmanufacturerslist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnmanufacturerslist.UseVisualStyleBackColor = false;
			this.btnmanufacturerslist.Click += new System.EventHandler(this.BtnmanufacturersClick);
			// 
			// btnpestsinsecticideslist
			// 
			this.btnpestsinsecticideslist.BackColor = System.Drawing.SystemColors.Control;
			this.btnpestsinsecticideslist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnpestsinsecticideslist.ForeColor = System.Drawing.Color.Black;
			this.btnpestsinsecticideslist.Image = ((System.Drawing.Image)(resources.GetObject("btnpestsinsecticideslist.Image")));
			this.btnpestsinsecticideslist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnpestsinsecticideslist.Location = new System.Drawing.Point(12, 253);
			this.btnpestsinsecticideslist.Name = "btnpestsinsecticideslist";
			this.btnpestsinsecticideslist.Size = new System.Drawing.Size(158, 38);
			this.btnpestsinsecticideslist.TabIndex = 6;
			this.btnpestsinsecticideslist.Text = "pestcides/insecticides";
			this.btnpestsinsecticideslist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnpestsinsecticideslist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnpestsinsecticideslist.UseVisualStyleBackColor = false;
			this.btnpestsinsecticideslist.Click += new System.EventHandler(this.BtnpestinsecticideClick);
			// 
			// btncropsdiseaseslist
			// 
			this.btncropsdiseaseslist.BackColor = System.Drawing.SystemColors.Control;
			this.btncropsdiseaseslist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncropsdiseaseslist.ForeColor = System.Drawing.Color.Black;
			this.btncropsdiseaseslist.Image = ((System.Drawing.Image)(resources.GetObject("btncropsdiseaseslist.Image")));
			this.btncropsdiseaseslist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncropsdiseaseslist.Location = new System.Drawing.Point(12, 210);
			this.btncropsdiseaseslist.Name = "btncropsdiseaseslist";
			this.btncropsdiseaseslist.Size = new System.Drawing.Size(158, 37);
			this.btncropsdiseaseslist.TabIndex = 5;
			this.btncropsdiseaseslist.Text = "diseases/pests";
			this.btncropsdiseaseslist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncropsdiseaseslist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncropsdiseaseslist.UseVisualStyleBackColor = false;
			this.btncropsdiseaseslist.Click += new System.EventHandler(this.BtncreatecropdiseaseClick);
			// 
			// btncropslist
			// 
			this.btncropslist.BackColor = System.Drawing.SystemColors.Control;
			this.btncropslist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncropslist.ForeColor = System.Drawing.Color.Black;
			this.btncropslist.Image = ((System.Drawing.Image)(resources.GetObject("btncropslist.Image")));
			this.btncropslist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncropslist.Location = new System.Drawing.Point(12, 55);
			this.btncropslist.Name = "btncropslist";
			this.btncropslist.Size = new System.Drawing.Size(158, 35);
			this.btncropslist.TabIndex = 1;
			this.btncropslist.Text = "crops";
			this.btncropslist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncropslist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncropslist.UseVisualStyleBackColor = false;
			this.btncropslist.Click += new System.EventHandler(this.BtncropslistClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtlog);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(433, 491);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// txtlog
			// 
			this.txtlog.BackColor = System.Drawing.Color.Black;
			this.txtlog.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtlog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtlog.ForeColor = System.Drawing.Color.Lime;
			this.txtlog.Location = new System.Drawing.Point(3, 16);
			this.txtlog.Multiline = true;
			this.txtlog.Name = "txtlog";
			this.txtlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtlog.Size = new System.Drawing.Size(427, 472);
			this.txtlog.TabIndex = 0;
			// 
			// notifyIconntharene
			// 
			this.notifyIconntharene.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIconntharene.BalloonTipText = "ntharene";
			this.notifyIconntharene.BalloonTipTitle = "ntharene";
			this.notifyIconntharene.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconntharene.Icon")));
			this.notifyIconntharene.Tag = "ntharene";
			this.notifyIconntharene.Text = "ntharene";
			this.notifyIconntharene.Visible = true;
			// 
			// MainForm
			// 
			this.AcceptButton = this.btncropslist;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnexit;
			this.ClientSize = new System.Drawing.Size(664, 541);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "farmers information manager";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgerror)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgwarn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imginfo)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.Button btndatabaseutils;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
		private System.Windows.Forms.Button btncategorieslist;
		private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStripMenuItem cropsvarietiesToolStripMenuItem;
		private System.Windows.Forms.Button btncropsvarietieslist;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
		private System.Windows.Forms.ToolStripMenuItem datastoreconfigmanagerutilsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem datastoreconfigmanagerToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
		private System.Windows.Forms.ToolStripMenuItem updatemssqldbschemaToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
		private System.Windows.Forms.ToolStripMenuItem updatemysqldbschemaToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripMenuItem updatesqlitedbschemaToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem updatepostgresqldbscemaToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem checkmssqlconnectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkmysqlconnectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checksqliteconnectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkpostgresqlconnectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createMssqlDatastoreToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createMysqlDatastoreToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createSqliteDatastoreToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createPostgresqlDatastoreToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mssqlToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mysqlToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sqliteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem postgresToolStripMenuItem;
		private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtoncheckdbconnections;
		private System.Windows.Forms.ToolStripStatusLabel lbltimelapsed;
		private System.Windows.Forms.ToolStripStatusLabel lbldatetime;
		private System.Windows.Forms.PictureBox imginfo;
		private System.Windows.Forms.PictureBox imgwarn;
		private System.Windows.Forms.PictureBox imgerror;
		private System.Windows.Forms.NotifyIcon notifyIconntharene;
		private System.Windows.Forms.Button btnexit;
		private System.Windows.Forms.Button btnsearch;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.Button btnsettingslist;
		private System.Windows.Forms.Button btnmanufacturerslist;
		private System.Windows.Forms.ToolStripMenuItem manufacturerToolStripMenuItem;
		private System.Windows.Forms.Button btnpestsinsecticideslist;
		private System.Windows.Forms.ToolStripMenuItem pestInsecticideToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem hometoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abouttoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helptoolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem cropsdiseaseslistToolStripMenuItem;
		private System.Windows.Forms.Button btncropsdiseaseslist;
		private System.Windows.Forms.Button btncropslist;
		private System.Windows.Forms.TextBox txtlog;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cropslistToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem filetoolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
	}
}
