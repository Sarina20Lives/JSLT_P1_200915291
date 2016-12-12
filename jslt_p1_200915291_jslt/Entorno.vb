Public Class Entorno

    Public ctxGlobal As ArrayList = New ArrayList
    Public ctxLocal As ArrayList = New ArrayList
    Public ambito As PtrJson = Nothing
    Public raiz As PtrJson = Nothing

    Public Function crearEntorno(ByRef contextoG As ArrayList, ByRef contextoL As ArrayList, ByVal amb As PtrJson, ByVal root As PtrJson)
        Dim entorno As Entorno = New Entorno
        entorno.ctxGlobal = contextoG
        entorno.ctxLocal = contextoL
        entorno.ambito = amb
        entorno.raiz = root
        Return entorno
    End Function

End Class
