Public Class Declarar

    Public Sub resolverDeclare(ByRef ent As Entorno, ByVal nodo As Nodo, ByVal gbl As Boolean)
        Dim var As Simbolo = New Simbolo
        var.rol = Constantes.R_VAR
        var.tipo = nodo.tipo
        var.nombre = nodo.cad
        var.instancia = False
        If (gbl) Then
            ent.ctxGlobal.Add(var)
            Return
        End If
        ent.ctxLocal.Add(var)
    End Sub

End Class
