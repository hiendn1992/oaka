<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MSS003
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MSS003))
        Me.lb_today = New System.Windows.Forms.Label
        Me.b_exit = New System.Windows.Forms.Button
        Me.b_cancel = New System.Windows.Forms.Button
        Me.b_exec = New System.Windows.Forms.Button
        Me.b_del_cus = New System.Windows.Forms.Button
        Me.b_add_cus = New System.Windows.Forms.Button
        Me.b_popup_cus = New System.Windows.Forms.Button
        Me.tb_cus_name = New System.Windows.Forms.TextBox
        Me.tb_cus_id = New System.Windows.Forms.TextBox
        Me.lb_cus_id = New System.Windows.Forms.Label
        Me.dgv_lst_cus = New System.Windows.Forms.DataGridView
        Me.b_popup_item = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tb_item_name = New System.Windows.Forms.TextBox
        Me.tb_quantity = New System.Windows.Forms.TextBox
        Me.tb_item_code = New System.Windows.Forms.TextBox
        Me.lb_quantity = New System.Windows.Forms.Label
        Me.lb_item_name = New System.Windows.Forms.Label
        Me.lb_item_code = New System.Windows.Forms.Label
        Me.rb_del = New System.Windows.Forms.RadioButton
        Me.rb_chg = New System.Windows.Forms.RadioButton
        Me.rb_add = New System.Windows.Forms.RadioButton
        Me.b_select_all = New System.Windows.Forms.Button
        Me.b_unselect_all = New System.Windows.Forms.Button
        Me.lbUnit = New System.Windows.Forms.Label
        Me.cbUnit = New System.Windows.Forms.ComboBox
        Me.lbTemplate = New System.Windows.Forms.Label
        Me.cbTemplate = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.b_browse_05 = New System.Windows.Forms.Button
        Me.b_browse_03 = New System.Windows.Forms.Button
        Me.b_browse_04 = New System.Windows.Forms.Button
        Me.b_browse_02 = New System.Windows.Forms.Button
        Me.b_browse_01 = New System.Windows.Forms.Button
        Me.tb_path_image_05 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.tb_path_image_04 = New System.Windows.Forms.TextBox
        Me.tb_path_image_03 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.tb_path_image_02 = New System.Windows.Forms.TextBox
        Me.tb_path_image_01 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.tb_orotex_no = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        CType(Me.dgv_lst_cus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_today
        '
        Me.lb_today.Location = New System.Drawing.Point(616, 2)
        Me.lb_today.Name = "lb_today"
        Me.lb_today.Size = New System.Drawing.Size(262, 14)
        Me.lb_today.TabIndex = 0
        Me.lb_today.Text = "User Id: XXXXXXXX  |  Today: dd/MM/yyyy"
        Me.lb_today.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(803, 512)
        Me.b_exit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(75, 22)
        Me.b_exit.TabIndex = 29
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'b_cancel
        '
        Me.b_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_cancel.Location = New System.Drawing.Point(722, 512)
        Me.b_cancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_cancel.Name = "b_cancel"
        Me.b_cancel.Size = New System.Drawing.Size(75, 22)
        Me.b_cancel.TabIndex = 28
        Me.b_cancel.Text = "Cancel"
        Me.b_cancel.UseVisualStyleBackColor = False
        '
        'b_exec
        '
        Me.b_exec.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exec.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exec.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exec.Location = New System.Drawing.Point(641, 512)
        Me.b_exec.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_exec.Name = "b_exec"
        Me.b_exec.Size = New System.Drawing.Size(75, 22)
        Me.b_exec.TabIndex = 27
        Me.b_exec.Text = "Execute"
        Me.b_exec.UseVisualStyleBackColor = False
        '
        'b_del_cus
        '
        Me.b_del_cus.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_del_cus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_del_cus.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_del_cus.Location = New System.Drawing.Point(265, 460)
        Me.b_del_cus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_del_cus.Name = "b_del_cus"
        Me.b_del_cus.Size = New System.Drawing.Size(75, 22)
        Me.b_del_cus.TabIndex = 23
        Me.b_del_cus.Text = "Delete"
        Me.b_del_cus.UseVisualStyleBackColor = False
        '
        'b_add_cus
        '
        Me.b_add_cus.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_add_cus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_add_cus.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_add_cus.Location = New System.Drawing.Point(184, 460)
        Me.b_add_cus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_add_cus.Name = "b_add_cus"
        Me.b_add_cus.Size = New System.Drawing.Size(75, 22)
        Me.b_add_cus.TabIndex = 22
        Me.b_add_cus.Text = "Add"
        Me.b_add_cus.UseVisualStyleBackColor = False
        '
        'b_popup_cus
        '
        Me.b_popup_cus.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_popup_cus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_popup_cus.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_popup_cus.Location = New System.Drawing.Point(213, 486)
        Me.b_popup_cus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_popup_cus.Name = "b_popup_cus"
        Me.b_popup_cus.Size = New System.Drawing.Size(24, 22)
        Me.b_popup_cus.TabIndex = 25
        Me.b_popup_cus.Text = "?"
        Me.b_popup_cus.UseVisualStyleBackColor = False
        '
        'tb_cus_name
        '
        Me.tb_cus_name.Enabled = False
        Me.tb_cus_name.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_cus_name.Location = New System.Drawing.Point(243, 486)
        Me.tb_cus_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_cus_name.MaxLength = 50
        Me.tb_cus_name.Name = "tb_cus_name"
        Me.tb_cus_name.Size = New System.Drawing.Size(284, 22)
        Me.tb_cus_name.TabIndex = 26
        '
        'tb_cus_id
        '
        Me.tb_cus_id.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_cus_id.Location = New System.Drawing.Point(73, 486)
        Me.tb_cus_id.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_cus_id.MaxLength = 10
        Me.tb_cus_id.Name = "tb_cus_id"
        Me.tb_cus_id.Size = New System.Drawing.Size(134, 22)
        Me.tb_cus_id.TabIndex = 24
        '
        'lb_cus_id
        '
        Me.lb_cus_id.AutoSize = True
        Me.lb_cus_id.Location = New System.Drawing.Point(9, 489)
        Me.lb_cus_id.Name = "lb_cus_id"
        Me.lb_cus_id.Size = New System.Drawing.Size(59, 14)
        Me.lb_cus_id.TabIndex = 21
        Me.lb_cus_id.Text = "Customer"
        '
        'dgv_lst_cus
        '
        Me.dgv_lst_cus.AllowUserToAddRows = False
        Me.dgv_lst_cus.AllowUserToDeleteRows = False
        Me.dgv_lst_cus.AllowUserToResizeRows = False
        Me.dgv_lst_cus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_lst_cus.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_lst_cus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_lst_cus.Location = New System.Drawing.Point(12, 202)
        Me.dgv_lst_cus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgv_lst_cus.Name = "dgv_lst_cus"
        Me.dgv_lst_cus.RowHeadersVisible = False
        Me.dgv_lst_cus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_lst_cus.Size = New System.Drawing.Size(866, 254)
        Me.dgv_lst_cus.TabIndex = 19
        Me.dgv_lst_cus.TabStop = False
        '
        'b_popup_item
        '
        Me.b_popup_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_popup_item.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_popup_item.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_popup_item.Location = New System.Drawing.Point(260, 41)
        Me.b_popup_item.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_popup_item.Name = "b_popup_item"
        Me.b_popup_item.Size = New System.Drawing.Size(24, 22)
        Me.b_popup_item.TabIndex = 2
        Me.b_popup_item.Text = "?"
        Me.b_popup_item.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(462, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 14)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(60, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 14)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(70, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 14)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "*"
        '
        'tb_item_name
        '
        Me.tb_item_name.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tb_item_name.Location = New System.Drawing.Point(482, 42)
        Me.tb_item_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_item_name.MaxLength = 100
        Me.tb_item_name.Name = "tb_item_name"
        Me.tb_item_name.Size = New System.Drawing.Size(396, 22)
        Me.tb_item_name.TabIndex = 3
        '
        'tb_quantity
        '
        Me.tb_quantity.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_quantity.Location = New System.Drawing.Point(93, 67)
        Me.tb_quantity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_quantity.MaxLength = 4
        Me.tb_quantity.Name = "tb_quantity"
        Me.tb_quantity.Size = New System.Drawing.Size(161, 22)
        Me.tb_quantity.TabIndex = 4
        Me.tb_quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tb_item_code
        '
        Me.tb_item_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_item_code.Location = New System.Drawing.Point(92, 41)
        Me.tb_item_code.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_item_code.MaxLength = 50
        Me.tb_item_code.Name = "tb_item_code"
        Me.tb_item_code.Size = New System.Drawing.Size(162, 22)
        Me.tb_item_code.TabIndex = 1
        '
        'lb_quantity
        '
        Me.lb_quantity.AutoSize = True
        Me.lb_quantity.Location = New System.Drawing.Point(9, 70)
        Me.lb_quantity.Name = "lb_quantity"
        Me.lb_quantity.Size = New System.Drawing.Size(54, 14)
        Me.lb_quantity.TabIndex = 31
        Me.lb_quantity.Text = "Quantity"
        '
        'lb_item_name
        '
        Me.lb_item_name.AutoSize = True
        Me.lb_item_name.Location = New System.Drawing.Point(398, 45)
        Me.lb_item_name.Name = "lb_item_name"
        Me.lb_item_name.Size = New System.Drawing.Size(68, 14)
        Me.lb_item_name.TabIndex = 30
        Me.lb_item_name.Text = "Item Name"
        '
        'lb_item_code
        '
        Me.lb_item_code.AutoSize = True
        Me.lb_item_code.Location = New System.Drawing.Point(9, 44)
        Me.lb_item_code.Name = "lb_item_code"
        Me.lb_item_code.Size = New System.Drawing.Size(65, 14)
        Me.lb_item_code.TabIndex = 28
        Me.lb_item_code.Text = "Item Code"
        '
        'rb_del
        '
        Me.rb_del.AutoSize = True
        Me.rb_del.Location = New System.Drawing.Point(137, 19)
        Me.rb_del.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rb_del.Name = "rb_del"
        Me.rb_del.Size = New System.Drawing.Size(61, 18)
        Me.rb_del.TabIndex = 40
        Me.rb_del.Text = "Delete"
        Me.rb_del.UseVisualStyleBackColor = True
        '
        'rb_chg
        '
        Me.rb_chg.AutoSize = True
        Me.rb_chg.Location = New System.Drawing.Point(65, 19)
        Me.rb_chg.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rb_chg.Name = "rb_chg"
        Me.rb_chg.Size = New System.Drawing.Size(66, 18)
        Me.rb_chg.TabIndex = 39
        Me.rb_chg.Text = "Change"
        Me.rb_chg.UseVisualStyleBackColor = True
        '
        'rb_add
        '
        Me.rb_add.AutoSize = True
        Me.rb_add.Location = New System.Drawing.Point(12, 19)
        Me.rb_add.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rb_add.Name = "rb_add"
        Me.rb_add.Size = New System.Drawing.Size(47, 18)
        Me.rb_add.TabIndex = 38
        Me.rb_add.Text = "Add"
        Me.rb_add.UseVisualStyleBackColor = True
        '
        'b_select_all
        '
        Me.b_select_all.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_select_all.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_select_all.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_select_all.Location = New System.Drawing.Point(12, 460)
        Me.b_select_all.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_select_all.Name = "b_select_all"
        Me.b_select_all.Size = New System.Drawing.Size(66, 22)
        Me.b_select_all.TabIndex = 20
        Me.b_select_all.Text = "Select All"
        Me.b_select_all.UseVisualStyleBackColor = False
        '
        'b_unselect_all
        '
        Me.b_unselect_all.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_unselect_all.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_unselect_all.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_unselect_all.Location = New System.Drawing.Point(84, 460)
        Me.b_unselect_all.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_unselect_all.Name = "b_unselect_all"
        Me.b_unselect_all.Size = New System.Drawing.Size(94, 22)
        Me.b_unselect_all.TabIndex = 21
        Me.b_unselect_all.Text = "Unselect All"
        Me.b_unselect_all.UseVisualStyleBackColor = False
        '
        'lbUnit
        '
        Me.lbUnit.AutoSize = True
        Me.lbUnit.Location = New System.Drawing.Point(398, 71)
        Me.lbUnit.Name = "lbUnit"
        Me.lbUnit.Size = New System.Drawing.Size(29, 14)
        Me.lbUnit.TabIndex = 43
        Me.lbUnit.Text = "Unit"
        '
        'cbUnit
        '
        Me.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUnit.FormattingEnabled = True
        Me.cbUnit.Location = New System.Drawing.Point(482, 68)
        Me.cbUnit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbUnit.Name = "cbUnit"
        Me.cbUnit.Size = New System.Drawing.Size(119, 22)
        Me.cbUnit.TabIndex = 5
        '
        'lbTemplate
        '
        Me.lbTemplate.AutoSize = True
        Me.lbTemplate.Location = New System.Drawing.Point(9, 96)
        Me.lbTemplate.Name = "lbTemplate"
        Me.lbTemplate.Size = New System.Drawing.Size(59, 14)
        Me.lbTemplate.TabIndex = 45
        Me.lbTemplate.Text = "Template"
        '
        'cbTemplate
        '
        Me.cbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTemplate.FormattingEnabled = True
        Me.cbTemplate.Location = New System.Drawing.Point(93, 93)
        Me.cbTemplate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbTemplate.Name = "cbTemplate"
        Me.cbTemplate.Size = New System.Drawing.Size(161, 22)
        Me.cbTemplate.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(64, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 14)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(425, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 14)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "*"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.b_browse_05)
        Me.GroupBox1.Controls.Add(Me.b_browse_03)
        Me.GroupBox1.Controls.Add(Me.b_browse_04)
        Me.GroupBox1.Controls.Add(Me.b_browse_02)
        Me.GroupBox1.Controls.Add(Me.b_browse_01)
        Me.GroupBox1.Controls.Add(Me.tb_path_image_05)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.tb_path_image_04)
        Me.GroupBox1.Controls.Add(Me.tb_path_image_03)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.tb_path_image_02)
        Me.GroupBox1.Controls.Add(Me.tb_path_image_01)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 119)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(868, 79)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Path Image:"
        '
        'b_browse_05
        '
        Me.b_browse_05.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_browse_05.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_browse_05.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_browse_05.Location = New System.Drawing.Point(838, 17)
        Me.b_browse_05.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_browse_05.Name = "b_browse_05"
        Me.b_browse_05.Size = New System.Drawing.Size(24, 22)
        Me.b_browse_05.TabIndex = 18
        Me.b_browse_05.Text = "..."
        Me.b_browse_05.UseVisualStyleBackColor = False
        '
        'b_browse_03
        '
        Me.b_browse_03.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_browse_03.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_browse_03.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_browse_03.Location = New System.Drawing.Point(518, 18)
        Me.b_browse_03.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_browse_03.Name = "b_browse_03"
        Me.b_browse_03.Size = New System.Drawing.Size(24, 22)
        Me.b_browse_03.TabIndex = 14
        Me.b_browse_03.Text = "..."
        Me.b_browse_03.UseVisualStyleBackColor = False
        '
        'b_browse_04
        '
        Me.b_browse_04.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_browse_04.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_browse_04.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_browse_04.Location = New System.Drawing.Point(518, 44)
        Me.b_browse_04.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_browse_04.Name = "b_browse_04"
        Me.b_browse_04.Size = New System.Drawing.Size(24, 22)
        Me.b_browse_04.TabIndex = 16
        Me.b_browse_04.Text = "..."
        Me.b_browse_04.UseVisualStyleBackColor = False
        '
        'b_browse_02
        '
        Me.b_browse_02.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_browse_02.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_browse_02.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_browse_02.Location = New System.Drawing.Point(208, 45)
        Me.b_browse_02.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_browse_02.Name = "b_browse_02"
        Me.b_browse_02.Size = New System.Drawing.Size(24, 22)
        Me.b_browse_02.TabIndex = 12
        Me.b_browse_02.Text = "..."
        Me.b_browse_02.UseVisualStyleBackColor = False
        '
        'b_browse_01
        '
        Me.b_browse_01.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_browse_01.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_browse_01.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_browse_01.Location = New System.Drawing.Point(208, 19)
        Me.b_browse_01.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_browse_01.Name = "b_browse_01"
        Me.b_browse_01.Size = New System.Drawing.Size(24, 22)
        Me.b_browse_01.TabIndex = 10
        Me.b_browse_01.Text = "..."
        Me.b_browse_01.UseVisualStyleBackColor = False
        '
        'tb_path_image_05
        '
        Me.tb_path_image_05.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_path_image_05.Location = New System.Drawing.Point(698, 17)
        Me.tb_path_image_05.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_path_image_05.Name = "tb_path_image_05"
        Me.tb_path_image_05.Size = New System.Drawing.Size(134, 22)
        Me.tb_path_image_05.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(640, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 14)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Image 5"
        '
        'tb_path_image_04
        '
        Me.tb_path_image_04.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_path_image_04.Location = New System.Drawing.Point(378, 44)
        Me.tb_path_image_04.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_path_image_04.Name = "tb_path_image_04"
        Me.tb_path_image_04.Size = New System.Drawing.Size(134, 22)
        Me.tb_path_image_04.TabIndex = 15
        '
        'tb_path_image_03
        '
        Me.tb_path_image_03.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_path_image_03.Location = New System.Drawing.Point(378, 18)
        Me.tb_path_image_03.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_path_image_03.Name = "tb_path_image_03"
        Me.tb_path_image_03.Size = New System.Drawing.Size(134, 22)
        Me.tb_path_image_03.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(320, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 14)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Image 4"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(320, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 14)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Image 3"
        '
        'tb_path_image_02
        '
        Me.tb_path_image_02.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_path_image_02.Location = New System.Drawing.Point(71, 44)
        Me.tb_path_image_02.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_path_image_02.Name = "tb_path_image_02"
        Me.tb_path_image_02.Size = New System.Drawing.Size(134, 22)
        Me.tb_path_image_02.TabIndex = 11
        '
        'tb_path_image_01
        '
        Me.tb_path_image_01.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_path_image_01.Location = New System.Drawing.Point(70, 19)
        Me.tb_path_image_01.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_path_image_01.Name = "tb_path_image_01"
        Me.tb_path_image_01.Size = New System.Drawing.Size(134, 22)
        Me.tb_path_image_01.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 14)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Image 2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 14)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Image 1"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(398, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 14)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Orotex No"
        '
        'tb_orotex_no
        '
        Me.tb_orotex_no.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_orotex_no.Location = New System.Drawing.Point(482, 94)
        Me.tb_orotex_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_orotex_no.MaxLength = 10
        Me.tb_orotex_no.Name = "tb_orotex_no"
        Me.tb_orotex_no.Size = New System.Drawing.Size(119, 22)
        Me.tb_orotex_no.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(458, 97)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(14, 14)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "*"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frm_MSS003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 542)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tb_orotex_no)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbTemplate)
        Me.Controls.Add(Me.lbTemplate)
        Me.Controls.Add(Me.cbUnit)
        Me.Controls.Add(Me.lbUnit)
        Me.Controls.Add(Me.b_unselect_all)
        Me.Controls.Add(Me.b_select_all)
        Me.Controls.Add(Me.rb_del)
        Me.Controls.Add(Me.rb_chg)
        Me.Controls.Add(Me.rb_add)
        Me.Controls.Add(Me.b_popup_item)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tb_item_name)
        Me.Controls.Add(Me.tb_quantity)
        Me.Controls.Add(Me.tb_item_code)
        Me.Controls.Add(Me.lb_quantity)
        Me.Controls.Add(Me.lb_item_name)
        Me.Controls.Add(Me.lb_item_code)
        Me.Controls.Add(Me.b_del_cus)
        Me.Controls.Add(Me.b_add_cus)
        Me.Controls.Add(Me.b_popup_cus)
        Me.Controls.Add(Me.tb_cus_name)
        Me.Controls.Add(Me.tb_cus_id)
        Me.Controls.Add(Me.lb_cus_id)
        Me.Controls.Add(Me.dgv_lst_cus)
        Me.Controls.Add(Me.b_exit)
        Me.Controls.Add(Me.b_cancel)
        Me.Controls.Add(Me.b_exec)
        Me.Controls.Add(Me.lb_today)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_MSS003"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Master Setup"
        CType(Me.dgv_lst_cus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_today As System.Windows.Forms.Label
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents b_cancel As System.Windows.Forms.Button
    Friend WithEvents b_exec As System.Windows.Forms.Button
    Friend WithEvents b_del_cus As System.Windows.Forms.Button
    Friend WithEvents b_add_cus As System.Windows.Forms.Button
    Friend WithEvents b_popup_cus As System.Windows.Forms.Button
    Friend WithEvents tb_cus_name As System.Windows.Forms.TextBox
    Friend WithEvents tb_cus_id As System.Windows.Forms.TextBox
    Friend WithEvents lb_cus_id As System.Windows.Forms.Label
    Friend WithEvents dgv_lst_cus As System.Windows.Forms.DataGridView
    Friend WithEvents b_popup_item As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_item_name As System.Windows.Forms.TextBox
    Friend WithEvents tb_quantity As System.Windows.Forms.TextBox
    Friend WithEvents tb_item_code As System.Windows.Forms.TextBox
    Friend WithEvents lb_quantity As System.Windows.Forms.Label
    Friend WithEvents lb_item_name As System.Windows.Forms.Label
    Friend WithEvents lb_item_code As System.Windows.Forms.Label
    Friend WithEvents rb_del As System.Windows.Forms.RadioButton
    Friend WithEvents rb_chg As System.Windows.Forms.RadioButton
    Friend WithEvents rb_add As System.Windows.Forms.RadioButton
    Friend WithEvents b_select_all As System.Windows.Forms.Button
    Friend WithEvents b_unselect_all As System.Windows.Forms.Button
    Friend WithEvents lbUnit As System.Windows.Forms.Label
    Friend WithEvents cbUnit As System.Windows.Forms.ComboBox
    Friend WithEvents lbTemplate As System.Windows.Forms.Label
    Friend WithEvents cbTemplate As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_path_image_02 As System.Windows.Forms.TextBox
    Friend WithEvents tb_path_image_01 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_path_image_05 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tb_path_image_04 As System.Windows.Forms.TextBox
    Friend WithEvents tb_path_image_03 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents b_browse_05 As System.Windows.Forms.Button
    Friend WithEvents b_browse_03 As System.Windows.Forms.Button
    Friend WithEvents b_browse_04 As System.Windows.Forms.Button
    Friend WithEvents b_browse_02 As System.Windows.Forms.Button
    Friend WithEvents b_browse_01 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tb_orotex_no As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
