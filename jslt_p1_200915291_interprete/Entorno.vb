Public Class Entorno

    Public ctxGlobal As ArrayList = New ArrayList
    Public ctxLocal As ArrayList = New ArrayList
    Public ambito As PtrJson = Nothing
    Public raiz As PtrJson = Nothing
    Public recorrido As String = ""

    Public Function crearEntorno(ByRef ent As Entorno)
        Dim entorno As Entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz
        entorno.recorrido = ent.recorrido
        Return entorno
    End Function

End Class
