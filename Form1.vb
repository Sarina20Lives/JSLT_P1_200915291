Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Nuevo()
    End Sub

    Private Sub Bnuevo_Click(sender As Object, e As EventArgs) Handles Bnuevo.Click
        Nuevo()
    End Sub

    Private Sub Banalizar_Click(sender As Object, e As EventArgs) Handles Banalizar.Click
        Accion(Acciones.Analizar)
    End Sub

    Private Sub Babrir_Click(sender As Object, e As EventArgs) Handles Babrir.Click
        Accion(Acciones.Abrir)
    End Sub

    Private Sub Bguardar_Click(sender As Object, e As EventArgs) Handles Bguardar.Click
        Accion(Acciones.Guardar)
    End Sub

    Private Sub BguardarComo_Click(sender As Object, e As EventArgs) Handles BguardarComo.Click
        Accion(Acciones.GuardarComo)
    End Sub

    Private Sub EvaluarCadena(ByVal text As String)
        Dim Cadena As System.IO.StringReader = New System.IO.StringReader(text)
        Setup()
        'false = json, true = jslt
        Dim analisis As Boolean = False
        Dim direccion As String = ""
        Dim raizJsl As Nodo = New Nodo
        Dim raizJson As PtrJson = New PtrJson
        Dim manArch As ManejoArchivos = New ManejoArchivos
        Parse(Cadena, analisis, raizJson, raizJsl, direccion)
        If (analisis) Then
            Dim transform As Transform = New Transform
            transform.resolverTransform(raizJsl, direccion)
        End If
    End Sub

    Private Sub Nuevo()
        Dim tab As Pestania = New Pestania()
        TabArchivos.TabPages.Add(tab)
    End Sub

    Private Sub Accion(ByVal act As Acciones)
        Dim i = TabArchivos.SelectedIndex
        If (i < 0) Then
            Return
        End If
        Dim tab As Pestania = TabArchivos.SelectedTab
        If (act = Acciones.Analizar) Then
            Dim entrada = tab.texto()
            EvaluarCadena(entrada)
        ElseIf (act = Acciones.Abrir) Then
            tab.abrir()
        ElseIf (act = Acciones.Guardar) Then
            tab.guardar()
        ElseIf (act = Acciones.GuardarComo) Then
            tab.guardarComo()
        End If

    End Sub

    Private Enum Acciones
        Abrir
        Guardar
        GuardarComo
        Analizar
    End Enum


End Class
