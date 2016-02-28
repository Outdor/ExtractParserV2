Public Class frmResults

    'Copyright (c) 2016, All Rights Reserved.
    'Author: Keith E. Coggin
    'Company: Sequoia Computer Services
    'Project Date: 2016-02-28 11:37
    'Summary: Report parsing tool created for use by DIY E-Liquid Supplies.

    'Structire to hold individual page details.
    Private Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure

    'Dictionary to hold collection for printed pages with index key.
    Private pages As Dictionary(Of Integer, pageDetails)

    'Global Variable Definitions
    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer

    Private Sub frmResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Allign the numeric data in the DataGridView to the right.
        Me.DataGridView1.Columns("DcBottleSizeDataGridViewTextBoxColumn").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView1.Columns("DcBottleCountDataGridViewTextBoxColumn").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Me.DataGridView2.Columns("DcTotalVolumeDataGridViewTextBoxColumn").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        'Shows a PrintPreviewDialog.
        Dim ppdResults As New PrintPreviewDialog
        ppdResults.Document = PrintDocument1
        ppdResults.WindowState = FormWindowState.Maximized
        ppdResults.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        'Prompt user for printer data.
        Dim result As DialogResult = PrintDialog1.ShowDialog()

        If (result = DialogResult.OK) Then
            'Start print job.
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Close the window.
        Me.Close()
    End Sub
    'The majority of this Sub is calculating printed page ranges.
    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        'This removes the printed page margins.
        PrintDocument1.OriginAtMargins = True
        PrintDocument1.DefaultPageSettings.Margins = New Drawing.Printing.Margins(0, 0, 0, 0)

        pages = New Dictionary(Of Integer, pageDetails)

        Dim maxWidth As Integer = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 40
        Dim maxHeight As Integer = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 40

        Dim pageCounter As Integer = 0
        pages.Add(pageCounter, New pageDetails)

        Dim columnCounter As Integer = 0

        'If first tab is selected.
        If TabControl1.SelectedIndex = 0 Then
            Dim columnSum As Integer = DataGridView1.RowHeadersWidth

            For c As Integer = 0 To DataGridView1.Columns.Count - 1
                If columnSum + DataGridView1.Columns(c).Width < maxWidth Then
                    columnSum += DataGridView1.Columns(c).Width
                    columnCounter += 1
                Else
                    pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                    columnSum = DataGridView1.RowHeadersWidth + DataGridView1.Columns(c).Width
                    columnCounter = 1
                    pageCounter += 1
                    pages.Add(pageCounter, New pageDetails With {.startCol = c})
                End If
                If c = DataGridView1.Columns.Count - 1 Then
                    If pages(pageCounter).columns = 0 Then
                        pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                    End If
                End If
            Next

            maxPagesWide = pages.Keys.Max + 1

            pageCounter = 0

            Dim rowCounter As Integer = 0

            Dim rowSum As Integer = DataGridView1.ColumnHeadersHeight

            For r As Integer = 0 To DataGridView1.Rows.Count - 2
                If rowSum + DataGridView1.Rows(r).Height < maxHeight Then
                    rowSum += DataGridView1.Rows(r).Height
                    rowCounter += 1
                Else
                    pages(pageCounter) = New pageDetails With {.columns = pages(pageCounter).columns, .rows = rowCounter, .startCol = pages(pageCounter).startCol, .startRow = pages(pageCounter).startRow}
                    For x As Integer = 1 To maxPagesWide - 1
                        pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter).startRow}
                    Next

                    pageCounter += maxPagesWide
                    For x As Integer = 0 To maxPagesWide - 1
                        pages.Add(pageCounter + x, New pageDetails With {.columns = pages(x).columns, .rows = 0, .startCol = pages(x).startCol, .startRow = r})
                    Next

                    rowSum = DataGridView1.ColumnHeadersHeight + DataGridView1.Rows(r).Height
                    rowCounter = 1
                End If
                If r = DataGridView1.Rows.Count - 2 Then
                    For x As Integer = 0 To maxPagesWide - 1
                        If pages(pageCounter + x).rows = 0 Then
                            pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter + x).startRow}
                        End If
                    Next
                End If
            Next

            'If second tab is selected.
        ElseIf TabControl1.SelectedIndex = 1 Then
            Dim columnSum As Integer = DataGridView2.RowHeadersWidth

            For c As Integer = 0 To DataGridView2.Columns.Count - 1
                If columnSum + DataGridView2.Columns(c).Width < maxWidth Then
                    columnSum += DataGridView2.Columns(c).Width
                    columnCounter += 1
                Else
                    pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                    columnSum = DataGridView2.RowHeadersWidth + DataGridView2.Columns(c).Width
                    columnCounter = 1
                    pageCounter += 1
                    pages.Add(pageCounter, New pageDetails With {.startCol = c})
                End If
                If c = DataGridView2.Columns.Count - 1 Then
                    If pages(pageCounter).columns = 0 Then
                        pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                    End If
                End If
            Next

            maxPagesWide = pages.Keys.Max + 1

            pageCounter = 0

            Dim rowCounter As Integer = 0

            Dim rowSum As Integer = DataGridView2.ColumnHeadersHeight

            For r As Integer = 0 To DataGridView2.Rows.Count - 2
                If rowSum + DataGridView2.Rows(r).Height < maxHeight Then
                    rowSum += DataGridView2.Rows(r).Height
                    rowCounter += 1
                Else
                    pages(pageCounter) = New pageDetails With {.columns = pages(pageCounter).columns, .rows = rowCounter, .startCol = pages(pageCounter).startCol, .startRow = pages(pageCounter).startRow}
                    For x As Integer = 1 To maxPagesWide - 1
                        pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter).startRow}
                    Next

                    pageCounter += maxPagesWide
                    For x As Integer = 0 To maxPagesWide - 1
                        pages.Add(pageCounter + x, New pageDetails With {.columns = pages(x).columns, .rows = 0, .startCol = pages(x).startCol, .startRow = r})
                    Next

                    rowSum = DataGridView2.ColumnHeadersHeight + DataGridView2.Rows(r).Height
                    rowCounter = 1
                End If
                If r = DataGridView2.Rows.Count - 2 Then
                    For x As Integer = 0 To maxPagesWide - 1
                        If pages(pageCounter + x).rows = 0 Then
                            pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter + x).startRow}
                        End If
                    Next
                End If
            Next
        End If

        maxPagesTall = pages.Count \ maxPagesWide

    End Sub

    'This is the actual printing routine.
    'Using the pageDetails calculated earlier, it prints a title,
    'and as much of the dataGridView as will fit on 1 page, then moves to the next page.
    'This is setup to be dynamic. try resizing the DGV columns or rows
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim rect As New Rectangle(20, 20, CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width), 0)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        sf.Alignment = StringAlignment.Near

        Dim startX As Integer = 50
        Dim startY As Integer = rect.Bottom

        Static startPage As Integer = 0

        'If first tab is selected.
        If TabControl1.SelectedIndex = 0 Then
            For p As Integer = startPage To pages.Count - 1
                Dim cell As New Rectangle(startX, startY, DataGridView1.RowHeadersWidth, DataGridView1.ColumnHeadersHeight)
                e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                e.Graphics.DrawRectangle(Pens.Black, cell)

                startX += cell.Width
                startY = rect.Bottom

                For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                    cell = New Rectangle(startX, startY, DataGridView1.Columns(c).Width, DataGridView1.ColumnHeadersHeight)
                    e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                    e.Graphics.DrawRectangle(Pens.Black, cell)
                    e.Graphics.DrawString(DataGridView1.Columns(c).HeaderCell.Value.ToString, DataGridView1.Font, Brushes.Black, cell, sf)
                    startX += DataGridView1.Columns(c).Width
                Next

                startY = rect.Bottom + DataGridView1.ColumnHeadersHeight

                For r As Integer = pages(p).startRow To pages(p).startRow + pages(p).rows - 1
                    startX = 50 + DataGridView1.RowHeadersWidth
                    For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                        cell = New Rectangle(startX, startY, DataGridView1.Columns(c).Width, DataGridView1.Rows(r).Height)
                        e.Graphics.DrawRectangle(Pens.Black, cell)
                        e.Graphics.DrawString(DataGridView1(c, r).Value.ToString, DataGridView1.Font, Brushes.Black, cell, sf)
                        startX += DataGridView1.Columns(c).Width
                    Next
                    startY += DataGridView1.Rows(r).Height
                Next

                If p <> pages.Count - 1 Then
                    startPage = p + 1
                    e.HasMorePages = True
                    Return
                Else
                    startPage = 0
                End If
            Next
            'If second tab is selected.
        ElseIf TabControl1.SelectedIndex = 1 Then
            For p As Integer = startPage To pages.Count - 1
                Dim cell As New Rectangle(startX, startY, DataGridView1.RowHeadersWidth, DataGridView1.ColumnHeadersHeight)
                e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                e.Graphics.DrawRectangle(Pens.Black, cell)

                startX += cell.Width
                startY = rect.Bottom

                For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                    cell = New Rectangle(startX, startY, DataGridView1.Columns(c).Width, DataGridView1.ColumnHeadersHeight)
                    e.Graphics.FillRectangle(New SolidBrush(SystemColors.ControlLight), cell)
                    e.Graphics.DrawRectangle(Pens.Black, cell)
                    e.Graphics.DrawString(DataGridView1.Columns(c).HeaderCell.Value.ToString, DataGridView1.Font, Brushes.Black, cell, sf)
                    startX += DataGridView1.Columns(c).Width
                Next

                startY = rect.Bottom + DataGridView1.ColumnHeadersHeight

                For r As Integer = pages(p).startRow To pages(p).startRow + pages(p).rows - 1
                    startX = 50 + DataGridView1.RowHeadersWidth
                    For c As Integer = pages(p).startCol To pages(p).startCol + pages(p).columns - 1
                        cell = New Rectangle(startX, startY, DataGridView1.Columns(c).Width, DataGridView1.Rows(r).Height)
                        e.Graphics.DrawRectangle(Pens.Black, cell)
                        e.Graphics.DrawString(DataGridView1(c, r).Value.ToString, DataGridView1.Font, Brushes.Black, cell, sf)
                        startX += DataGridView1.Columns(c).Width
                    Next
                    startY += DataGridView1.Rows(r).Height
                Next

                If p <> pages.Count - 1 Then
                    startPage = p + 1
                    e.HasMorePages = True
                    Return
                Else
                    startPage = 0
                End If
            Next
        End If
    End Sub
End Class