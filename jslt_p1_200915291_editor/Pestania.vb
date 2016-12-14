Imports FastColoredTextBoxNS
Imports System.Text.RegularExpressions

Public Class Pestania
    Inherits System.Windows.Forms.TabPage

    Private popupMenu As AutocompleteMenu

    Private keywords As String() = { _
        "entero", "doble", "boolean", "caracter", "cadena", _
        "div", "border", "bgcolor", "width", "height", _
        "ruta", "version", "seleccionar", "variable", "nombreObj", _
        "condicion", "valor" _
    }

    Private declarationHtml As String() = { _
        "<jsl:transformacion ruta="""" version="""">" & vbLf & "^" & vbLf & "</jsl:final>", _
        "<jsl:variable tipo = id^/>", _
        "<jsl:asignar variable = id valor = expresion^/>", _
        "<jsl:plantilla nombreObj = id>" & vbLf & "^" & vbLf & "</jsl:plantilla>", _
        "<jsl:plantilla-aplicar seleccionar = id^/>", _
        "<jsl:valor-de seleccionar = id^/>", _
        "<jsl:para-cada seleccionar = id>" & vbLf & "^" & vbLf & "</jsl:para-cada>", _
        "<jsl:if condicion = expresion>" & vbLf & "^" & vbLf & "</jsl:if>", _
        "<jsl:en-caso>" & vbLf & "^" & vbLf & "</jsl:en-caso>", _
        "<jsl:de condicion = expresion>" & vbLf & "^" & vbLf & "</jsl:de>", _
        "<jsl:cualquier-otro>" & vbLf & "^" & vbLf & "</jsl:cualquier-otro>", _
        "<html>" & vbLf & "^" & vbLf & "</html>", _
        "<body>" & vbLf & "^" & vbLf & "</body>", _
        "<head>" & vbLf & "<title>" & vbLf & "^" & vbLf & "</title>" & vbLf & "</head>", _
        "<h1>^</h1>", "<h2>^</h2>", "<h3>^</h3>", "<h4>^</h4>", "<h5>^</h5>", "<h6>^</h6>", _
        "<p>^</p>", "<b>^</b>", "<i>^</i>", "<th>^</th>", "<td>^</td>", _
        "<table border=""^"" bgcolor="""" width="""">" & vbLf & "<tr>" & vbLf & "<th></th>" & vbLf & "</tr>" & vbLf & "<tr>" & vbLf & "<td></td>" & vbLf & "</tr>" & vbLf & "</table>", _
        "<tr>" & vbLf & "<th>^</th>" & vbLf & "</tr>", _
        "<tr>" & vbLf & "<td>^</td>" & vbLf & "</tr>"
    }

    Public Sub New()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pestania))
        Me.fctb = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.iconsList = New System.Windows.Forms.ImageList()
        Me.SuspendLayout()
        '
        'fctb
        '
        Me.fctb.AutoScrollMinSize = New System.Drawing.Size(466, 330)
        Me.fctb.BackBrush = Nothing
        Me.fctb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fctb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.fctb.DelayedEventsInterval = 500
        Me.fctb.DelayedTextChangedInterval = 500
        Me.fctb.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.fctb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fctb.Font = New System.Drawing.Font("Consolas", 9.75!)
        Me.fctb.Language = FastColoredTextBoxNS.Language.Custom
        Me.fctb.HighlightingRangeType = HighlightingRangeType.AllTextRange
        Me.fctb.DescriptionFile = "jslDesc.xml"
        Me.fctb.LeftBracket = "<"
        Me.fctb.Location = New System.Drawing.Point(0, 85)
        Me.fctb.Name = "fctb"
        Me.fctb.Paddings = New System.Windows.Forms.Padding(0)
        Me.fctb.RightBracket = ">"
        Me.fctb.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fctb.Size = New System.Drawing.Size(500, 280)
        Me.fctb.TabIndex = 7
        Me.fctb.BorderStyle = Windows.Forms.BorderStyle.None
        Me.fctb.AutoIndent = True
        'Me.fctb.Text = resources.GetString("fctb.Text")
        '
        'imageList1
        '
        Me.iconsList.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iconsList.TransparentColor = System.Drawing.Color.Transparent
        Me.iconsList.Images.SetKeyName(0, "script_16x16.png")
        Me.iconsList.Images.SetKeyName(1, "app_16x16.png")
        Me.iconsList.Images.SetKeyName(2, "1302166543_virtualbox.png")
        '
        'tabPage
        '
        Me.ClientSize = New System.Drawing.Size(500, 365)
        Me.Controls.Add(Me.fctb)
        Me.ResumeLayout(False)
        Me.Text = "Sin guardar*"
        Me.BorderStyle = Windows.Forms.BorderStyle.None
        popupMenu = New AutocompleteMenu(fctb)
        popupMenu.Items.ImageList = iconsList
        popupMenu.SearchPattern = "[\w\.:=!<>]"        '
        BuildAutocompleteMenu()
    End Sub

    Public Sub abrir()
        Dim openDialog As New OpenFileDialog()
        openDialog.Filter = "Archivos JSL (*.jsl)|*.jsl|Archivos JSON (*.json)|*.json"
        openDialog.FilterIndex = 1
        If openDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.Text = openDialog.SafeFileName
            Me.ToolTipText = openDialog.FileName
            Me.fctb.OpenFile(Me.ToolTipText)
        End If
    End Sub

    Public Sub guardarComo()
        Dim saveDialog As New SaveFileDialog()
        saveDialog.Filter = "Archivos JSL (*.jsl)|*.jsl|Archivos JSON (*.json)|*.json"
        saveDialog.FilterIndex = 1
        If saveDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Dim destino = saveDialog.FileName
            Dim i = destino.LastIndexOf("\") + 1
            Me.Text = destino.Substring(i)
            Me.ToolTipText = destino
            Me.fctb.SaveToFile(destino, System.Text.Encoding.UTF8)
        End If
    End Sub

    Public Sub guardar()
        Dim destino = Me.Text
        If (destino.Contains("*")) Then
            guardarComo()
        Else
            destino = Me.ToolTipText
            Me.fctb.SaveToFile(destino, System.Text.Encoding.UTF8)
        End If
    End Sub

    Public Function texto()
        Return Me.fctb.Text
    End Function

    Private Sub BuildAutocompleteMenu()
        Dim items As New List(Of AutocompleteItem)()

        For Each item As String In declarationHtml
            items.Add(New DeclarationSnippet(item) With {.ImageIndex = 0})
        Next

        For Each item As String In keywords
            items.Add(New AutocompleteItem(item))
        Next

        items.Add(New InsertSpaceSnippet())
        items.Add(New InsertSpaceSnippet("^(\w+)([=<>!:]+)(\w+)$"))
        items.Add(New InsertEnterSnippet())

        'set as autocomplete source
        popupMenu.Items.SetAutocompleteItems(items)
    End Sub

    ''' <summary>
    ''' This item appears when any part of snippet text is typed
    ''' </summary>
    Private Class DeclarationSnippet
        Inherits SnippetAutocompleteItem
        Public Sub New(ByVal snippet As String)
            MyBase.New(snippet)
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            Dim pattern = Regex.Escape(fragmentText)
            If Regex.IsMatch(Text, "\b" & pattern, RegexOptions.IgnoreCase) Then
                Return CompareResult.Visible
            End If
            Return CompareResult.Hidden
        End Function
    End Class

    ''' <summary>
    ''' Divides numbers and words: "123AND456" -> "123 AND 456"
    ''' Or "i=2" -> "i = 2"
    ''' </summary>
    Private Class InsertSpaceSnippet
        Inherits AutocompleteItem
        Private pattern As String

        Public Sub New(ByVal pattern As String)
            MyBase.New("")
            Me.pattern = pattern
        End Sub


        Public Sub New()
            Me.New("^(\d+)([a-zA-Z_]+)(\d*)$")
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            If Regex.IsMatch(fragmentText, pattern) Then
                Text = InsertSpaces(fragmentText)
                If Text <> fragmentText Then
                    Return CompareResult.Visible
                End If
            End If
            Return CompareResult.Hidden
        End Function

        Public Function InsertSpaces(ByVal fragment As String) As String
            Dim m = Regex.Match(fragment, pattern)
            If m Is Nothing Then
                Return fragment
            End If
            If m.Groups(1).Value = "" AndAlso m.Groups(3).Value = "" Then
                Return fragment
            End If
            Return (m.Groups(1).Value & " " & m.Groups(2).Value & " " & m.Groups(3).Value).Trim()
        End Function

        Public Overrides Property ToolTipTitle() As String
            Get
                Return Text
            End Get
            Set(ByVal value As String)
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Inerts line break after '>'
    ''' </summary>
    Private Class InsertEnterSnippet
        Inherits AutocompleteItem
        Private enterPlace As Place = Place.Empty

        Public Sub New()
            MyBase.New("[Line break]")
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            Dim r = Parent.Fragment.Clone()
            While r.Start.iChar > 0
                If r.CharBeforeStart = ">"c Then
                    enterPlace = r.Start
                    Return CompareResult.Visible
                End If

                r.GoLeftThroughFolded()
            End While

            Return CompareResult.Hidden
        End Function

        Public Overrides Function GetTextForReplace() As String
            'extend range
            Dim r As Range = Parent.Fragment
            Dim [end] As Place = r.[End]
            r.Start = enterPlace
            r.[End] = r.[End]
            'insert line break
            Return Environment.NewLine + r.Text
        End Function

        Public Overrides Sub OnSelected(ByVal popupMenu As AutocompleteMenu, ByVal e As SelectedEventArgs)
            MyBase.OnSelected(popupMenu, e)
            If Parent.Fragment.tb.AutoIndent Then
                Parent.Fragment.tb.DoAutoIndent()
            End If
        End Sub

        Public Overrides Property ToolTipTitle() As String
            Get
                Return "Insert line break after '>'"
            End Get
            Set(ByVal value As String)
            End Set
        End Property
    End Class

    Private WithEvents fctb As FastColoredTextBoxNS.FastColoredTextBox
    Private WithEvents iconsList As System.Windows.Forms.ImageList
End Class
