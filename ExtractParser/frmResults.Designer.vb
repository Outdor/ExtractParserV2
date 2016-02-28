<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResults
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
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.DcExtractNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DcBottleSizeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DcBottleCountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtExtractBottlesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsExtractBottles = New ExtractParser.dsExtractBottles()
        Me.DcExtractNameDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DcTotalVolumeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtExtractVolumeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsExtractVolume = New ExtractParser.dsExtractVolume()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtExtractBottlesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsExtractBottles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtExtractVolumeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsExtractVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(13, 13)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(592, 580)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(584, 554)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Bottle Count"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DcExtractNameDataGridViewTextBoxColumn, Me.DcBottleSizeDataGridViewTextBoxColumn, Me.DcBottleCountDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.DtExtractBottlesBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(578, 548)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(584, 554)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Total Volume"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DcExtractNameDataGridViewTextBoxColumn1, Me.DcTotalVolumeDataGridViewTextBoxColumn})
        Me.DataGridView2.DataSource = Me.DtExtractVolumeBindingSource
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(578, 548)
        Me.DataGridView2.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(117, 599)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(99, 23)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(12, 599)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(99, 23)
        Me.btnPreview.TabIndex = 0
        Me.btnPreview.Text = "Print Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(506, 599)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(99, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'DcExtractNameDataGridViewTextBoxColumn
        '
        Me.DcExtractNameDataGridViewTextBoxColumn.DataPropertyName = "dcExtractName"
        Me.DcExtractNameDataGridViewTextBoxColumn.HeaderText = "Extract Name"
        Me.DcExtractNameDataGridViewTextBoxColumn.Name = "DcExtractNameDataGridViewTextBoxColumn"
        Me.DcExtractNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.DcExtractNameDataGridViewTextBoxColumn.Width = 250
        '
        'DcBottleSizeDataGridViewTextBoxColumn
        '
        Me.DcBottleSizeDataGridViewTextBoxColumn.DataPropertyName = "dcBottleSize"
        Me.DcBottleSizeDataGridViewTextBoxColumn.HeaderText = "Bottle Size"
        Me.DcBottleSizeDataGridViewTextBoxColumn.Name = "DcBottleSizeDataGridViewTextBoxColumn"
        Me.DcBottleSizeDataGridViewTextBoxColumn.ReadOnly = True
        Me.DcBottleSizeDataGridViewTextBoxColumn.Width = 80
        '
        'DcBottleCountDataGridViewTextBoxColumn
        '
        Me.DcBottleCountDataGridViewTextBoxColumn.DataPropertyName = "dcBottleCount"
        Me.DcBottleCountDataGridViewTextBoxColumn.HeaderText = "Bottle Count"
        Me.DcBottleCountDataGridViewTextBoxColumn.Name = "DcBottleCountDataGridViewTextBoxColumn"
        Me.DcBottleCountDataGridViewTextBoxColumn.ReadOnly = True
        Me.DcBottleCountDataGridViewTextBoxColumn.Width = 90
        '
        'DtExtractBottlesBindingSource
        '
        Me.DtExtractBottlesBindingSource.DataMember = "dtExtractBottles"
        Me.DtExtractBottlesBindingSource.DataSource = Me.DsExtractBottles
        '
        'DsExtractBottles
        '
        Me.DsExtractBottles.DataSetName = "dsExtractBottles"
        Me.DsExtractBottles.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DcExtractNameDataGridViewTextBoxColumn1
        '
        Me.DcExtractNameDataGridViewTextBoxColumn1.DataPropertyName = "dcExtractName"
        Me.DcExtractNameDataGridViewTextBoxColumn1.HeaderText = "Extract Name"
        Me.DcExtractNameDataGridViewTextBoxColumn1.Name = "DcExtractNameDataGridViewTextBoxColumn1"
        Me.DcExtractNameDataGridViewTextBoxColumn1.ReadOnly = True
        Me.DcExtractNameDataGridViewTextBoxColumn1.Width = 250
        '
        'DcTotalVolumeDataGridViewTextBoxColumn
        '
        Me.DcTotalVolumeDataGridViewTextBoxColumn.DataPropertyName = "dcTotalVolume"
        Me.DcTotalVolumeDataGridViewTextBoxColumn.HeaderText = "Total Volume"
        Me.DcTotalVolumeDataGridViewTextBoxColumn.Name = "DcTotalVolumeDataGridViewTextBoxColumn"
        Me.DcTotalVolumeDataGridViewTextBoxColumn.ReadOnly = True
        Me.DcTotalVolumeDataGridViewTextBoxColumn.Width = 95
        '
        'DtExtractVolumeBindingSource
        '
        Me.DtExtractVolumeBindingSource.DataMember = "dtExtractVolume"
        Me.DtExtractVolumeBindingSource.DataSource = Me.DsExtractVolume
        '
        'DsExtractVolume
        '
        Me.DsExtractVolume.DataSetName = "dsExtractVolume"
        Me.DsExtractVolume.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 634)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmResults"
        Me.Text = "frmResults"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtExtractBottlesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsExtractBottles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtExtractVolumeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsExtractVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DsExtractBottles As dsExtractBottles
    Friend WithEvents DsExtractVolume As dsExtractVolume
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DtExtractBottlesBindingSource As BindingSource
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DtExtractVolumeBindingSource As BindingSource
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnPreview As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents DcExtractNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DcBottleSizeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DcBottleCountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DcExtractNameDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DcTotalVolumeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
