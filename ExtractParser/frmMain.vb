Public Class frmMain

    'Copyright (c) 2016, All Rights Reserved.
    'Author: Keith E. Coggin
    'Company: Sequoia Computer Services
    'Project Date: 2016-02-28 11:37
    'Summary: Report parsing tool created for use by DIY E-Liquid Supplies.

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Variable Declarations.
        Dim StringReader As String 'Variable to hold individual lines from the file.
        Dim SplitLine() As String 'Array to hold the seperated vales from a single line in the file.
        Dim Extracts(2, 0) As String 'Declare dynamic arrays for orders.
        Dim ExtractByName(2, 0) As String 'Dynamic array for Extracts Sold, sorted by Name.
        'Dim ExtractByVolume(2, 0) As String 'Dynamic array for Extracts Sold, sorted by Volume.
        Dim ExtractTotalVolumeByName(1, 0) As String 'Dynamic array for Total Volume of Extract Sold by name.
        'Dim ExtractTotalVolumeByVolume(1, 0) As String 'Dynamic array for Total Volume of Extract Sold by name.
        Dim Count As UShort 'Number of lines for Bubble Sort.
        Dim NameSwap As Boolean = True 'Outer Bubble sort finished check.
        Dim SizeSwap As Boolean = True 'Inner Bubble sort finished check.
        'Dim NewFileName As String 'Name of Output file.

        'Display the open file dialog.
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
        End If

        'Create a streamreader for the selected file.
        Dim FileReader = New System.IO.StreamReader(OpenFileDialog1.FileName)

        'Add headers to Array.
        Extracts(0, UBound(Extracts, 2)) = "Name"
        Extracts(1, UBound(Extracts, 2)) = "Size"
        Extracts(2, UBound(Extracts, 2)) = "Quantity"

        'Create a loop to parse through the file.
        While FileReader.Peek >= 0

            'Read the next line form the file.
            StringReader = FileReader.ReadLine

            'Split the line into the array.
            SplitLine = StringReader.Split(",")

            'Check if line contains relevant data.
            If SplitLine(0) = "10ml Extract Bottle" Or
                SplitLine(0) = "30ml Extract Bottle" Or
                SplitLine(5).Contains("ml") Then

                'Resize the array to contain a new entry.
                ReDim Preserve Extracts(UBound(Extracts, 1), UBound(Extracts, 2) + 1)

                'Determin the format of the data in the line.
                If SplitLine(0) = "10ml Extract Bottle" Then
                    'Store data for 10ml Extracts Bottles.
                    Extracts(0, UBound(Extracts, 2)) = SplitLine(5)
                    Extracts(1, UBound(Extracts, 2)) = "010"
                    Extracts(2, UBound(Extracts, 2)) = SplitLine(1)
                ElseIf SplitLine(0) = "30ml Extract Bottle" Then
                    'Store data for 10ml Extracts Bottles.
                    Extracts(0, UBound(Extracts, 2)) = SplitLine(5)
                    Extracts(1, UBound(Extracts, 2)) = "030"
                    Extracts(2, UBound(Extracts, 2)) = SplitLine(1)
                ElseIf SplitLine(5).Contains("ml") Then
                    'Store data for Extracts.
                    Extracts(0, UBound(Extracts, 2)) = SplitLine(0)
                    Extracts(1, UBound(Extracts, 2)) = SplitLine(5).TrimEnd("m", "l")
                    Extracts(2, UBound(Extracts, 2)) = SplitLine(1)

                    'Check the length of the of the volume and add leading zeros.
                    If Extracts(1, UBound(Extracts, 2)).Length() = 2 Then
                        Extracts(1, UBound(Extracts, 2)) = "0" + Extracts(1, UBound(Extracts, 2))
                    End If
                End If
            End If
        End While

        'Close StreamReader Objects.
        FileReader.Close()

        'Resize the SplitLine array for use in the bubble sort.
        ReDim SplitLine(2)

        'Determine the number of entries in the Extracts.
        Count = UBound(Extracts, 2)

        'Outer loop for Outer Bubble Sort.
        Do While NameSwap = True Or SizeSwap = True
            'Reset the finished check.
            NameSwap = False
            SizeSwap = False

            'Inner loop for Outer Bubble Sort.
            For i = 2 To Count
                'Test for Name order.
                If Extracts(0, i - 1) > Extracts(0, i) Then
                    'Swap them and mark that a change has been made.
                    SplitLine(0) = Extracts(0, i - 1)
                    SplitLine(1) = Extracts(1, i - 1)
                    SplitLine(2) = Extracts(2, i - 1)
                    Extracts(0, i - 1) = Extracts(0, i)
                    Extracts(1, i - 1) = Extracts(1, i)
                    Extracts(2, i - 1) = Extracts(2, i)
                    Extracts(0, i) = SplitLine(0)
                    Extracts(1, i) = SplitLine(1)
                    Extracts(2, i) = SplitLine(2)
                    NameSwap = True
                End If

                'Test for Size order.
                If Extracts(0, i - 1) = Extracts(0, i) Then
                    If Extracts(1, i - 1) > Extracts(1, i) Then
                        'Swap them and mark that a change has been made.
                        SplitLine(0) = Extracts(0, i - 1)
                        SplitLine(1) = Extracts(1, i - 1)
                        SplitLine(2) = Extracts(2, i - 1)
                        Extracts(0, i - 1) = Extracts(0, i)
                        Extracts(1, i - 1) = Extracts(1, i)
                        Extracts(2, i - 1) = Extracts(2, i)
                        Extracts(0, i) = SplitLine(0)
                        Extracts(1, i) = SplitLine(1)
                        Extracts(2, i) = SplitLine(2)
                        SizeSwap = True
                    End If

                    'Test for duplicate Sizes and that value is not Null.
                    If Extracts(1, i - 1) = Extracts(1, i) And Extracts(1, i - 1) IsNot "" Then
                        Extracts(2, i - 1) = CInt(Extracts(2, i - 1)) + CInt(Extracts(2, i))
                        Extracts(0, i) = ""
                        Extracts(1, i) = ""
                        Extracts(2, i) = ""
                    End If
                End If
            Next
        Loop

        'Add headers to ByName Array.
        ExtractByName(0, UBound(ExtractByName, 2)) = "Name"
        ExtractByName(1, UBound(ExtractByName, 2)) = "Size"
        ExtractByName(2, UBound(ExtractByName, 2)) = "Quantity"

        'Create by name array.
        For i = 1 To Count
            'Eliminate Null entries.
            If Extracts(0, i) IsNot "" Then

                'Resize the array to contain a new entry.
                ReDim Preserve ExtractByName(UBound(ExtractByName, 1), UBound(ExtractByName, 2) + 1)

                'Populate new array.
                ExtractByName(0, UBound(ExtractByName, 2)) = Extracts(0, i)
                ExtractByName(1, UBound(ExtractByName, 2)) = Extracts(1, i)
                ExtractByName(2, UBound(ExtractByName, 2)) = Extracts(2, i)
            End If
        Next

        'Reset the finished check.
        NameSwap = True
        SizeSwap = True

        'Resort Extracts Array by Number.
        Do While NameSwap = True Or SizeSwap = True
            'Reset the finished check.
            NameSwap = False
            SizeSwap = False

            'Inner loop for Outer Bubble Sort.
            For i = 2 To Count
                'Test for Name order.
                If Extracts(1, i - 1) > Extracts(1, i) Then
                    'Swap them and mark that a change has been made.
                    SplitLine(0) = Extracts(0, i - 1)
                    SplitLine(1) = Extracts(1, i - 1)
                    SplitLine(2) = Extracts(2, i - 1)
                    Extracts(0, i - 1) = Extracts(0, i)
                    Extracts(1, i - 1) = Extracts(1, i)
                    Extracts(2, i - 1) = Extracts(2, i)
                    Extracts(0, i) = SplitLine(0)
                    Extracts(1, i) = SplitLine(1)
                    Extracts(2, i) = SplitLine(2)
                    NameSwap = True
                End If

                'Test for Size order.
                If Extracts(1, i - 1) = Extracts(1, i) Then
                    If Extracts(0, i - 1) > Extracts(0, i) Then
                        'Swap them and mark that a change has been made.
                        SplitLine(0) = Extracts(0, i - 1)
                        SplitLine(1) = Extracts(1, i - 1)
                        SplitLine(2) = Extracts(2, i - 1)
                        Extracts(0, i - 1) = Extracts(0, i)
                        Extracts(1, i - 1) = Extracts(1, i)
                        Extracts(2, i - 1) = Extracts(2, i)
                        Extracts(0, i) = SplitLine(0)
                        Extracts(1, i) = SplitLine(1)
                        Extracts(2, i) = SplitLine(2)
                        SizeSwap = True
                    End If

                End If
            Next
        Loop

        'Add headers to ExtractTotalVolumeByName Array.
        ExtractTotalVolumeByName(0, UBound(ExtractTotalVolumeByName, 2)) = "Name"
        ExtractTotalVolumeByName(1, UBound(ExtractTotalVolumeByName, 2)) = "Quantity"

        'Determine the number of entries in the ExtractsByName.
        Count = UBound(ExtractByName, 2)

        'Null out SplitLine.
        SplitLine(0) = ""

        'Loop through and calculate total sales by name.
        For i = 1 To Count
            'Eliminate Null entries.
            If ExtractByName(0, i) <> SplitLine(0) Then

                'Copy the Data to SplitLine.
                SplitLine(0) = ExtractByName(0, i)
                SplitLine(1) = ExtractByName(1, i)
                SplitLine(2) = ExtractByName(2, i)

                'Resize the array to contain a new entry.
                ReDim Preserve ExtractTotalVolumeByName(UBound(ExtractTotalVolumeByName, 1), UBound(ExtractTotalVolumeByName, 2) + 1)

                'Create entry in ExtractTotalVolumeByName.
                ExtractTotalVolumeByName(0, UBound(ExtractTotalVolumeByName, 2)) = ExtractByName(0, i)
                ExtractTotalVolumeByName(1, UBound(ExtractTotalVolumeByName, 2)) = ExtractByName(1, i) * ExtractByName(2, i)

            ElseIf ExtractByName(0, i) = SplitLine(0) Then
                'Update entry in ExtractTotalVolumeByName.
                ExtractTotalVolumeByName(1, UBound(ExtractTotalVolumeByName, 2)) = ExtractTotalVolumeByName(1, UBound(ExtractTotalVolumeByName, 2)) + (ExtractByName(1, i) * ExtractByName(2, i))
            End If
        Next

        'Instantiate Results form.
        Dim frmResults As New frmResults

        'Loop through the ExtractByName Array writing to the Dataset.
        For i = 1 To UBound(ExtractByName, 2)
            'Create a DataRow object to be added to the By Bottle DataSet.
            Dim drBottleRow As DataRow = frmResults.DsExtractBottles.dtExtractBottles.NewRow()

            'Populate the DataRow object with the next extract.
            drBottleRow(0) = ExtractByName(0, i)
            drBottleRow(1) = ExtractByName(1, i)
            drBottleRow(2) = ExtractByName(2, i)

            'Add new row to the DataSet.
            frmResults.DsExtractBottles.dtExtractBottles.Rows.Add(drBottleRow)
        Next

        'Loop through the ExtractByName Array writing to the Dataset.
        For i = 1 To UBound(ExtractTotalVolumeByName, 2)
            'Create a DataRow object to be added to the By Volume DataSet.
            Dim drVolumeRow As DataRow = frmResults.DsExtractVolume.dtExtractVolume.NewRow()

            'Populate the DataRow object with the next extract.
            drVolumeRow(0) = ExtractTotalVolumeByName(0, i)
            drVolumeRow(1) = ExtractTotalVolumeByName(1, i)

            'Add new row to the DataSet.
            frmResults.DsExtractVolume.dtExtractVolume.Rows.Add(drVolumeRow)
        Next

        'Display the results form.
        frmResults.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Exit the application.
        Application.Exit()

        'Output Test
        'MessageBox.Show(StringReader)
        'MessageBox.Show(SplitLine(0) + ", " + SplitLine(1) + ", " + SplitLine(5))
        'MessageBox.Show(Extracts(0, UBound(Extracts, 2)) + ", " + Extracts(1, UBound(Extracts, 2)) + ", " + Extracts(2, UBound(Extracts, 2)))
    End Sub
End Class
