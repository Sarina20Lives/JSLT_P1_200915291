Public Class GetVal

    Private entorno As Entorno = Nothing
    Private manArch As ManejoArchivos = New ManejoArchivos


    Public Sub resolver(ByRef ent As Entorno, ByVal obj As Nodo)
        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz
        Dim acc As Acceso = New Acceso
        Dim resultado As Resultado = New Resultado
        resultado = acc.getVal(entorno, obj)
        If (resultado.tipo <> Constantes.ERR) Then
            manArch.appendHtml(resultado.valor)
        End If
    End Sub



    End Class
