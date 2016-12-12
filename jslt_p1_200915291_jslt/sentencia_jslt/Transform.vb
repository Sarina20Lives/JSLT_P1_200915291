Public Class Transform

    Dim manArch As ManejoArchivos = New ManejoArchivos

    Public Sub resolverTransform(ByVal raiz As Nodo)
        Dim entorno As Entorno = New Entorno
        Dim plantilla As Plantilla = Nothing
        Dim declarre As Declarar = Nothing

        manArch.escribirHtml("")

        Dim obj As Nodo
        For Each obj In raiz.hijos
            If (obj.subrol = Constantes.SR_DECLARE) Then
                declarre = New Declarar
                declarre.resolverDeclare(entorno, obj, True)
            End If
            If (obj.subrol = Constantes.SR_PLANTILLA) Then
                plantilla = New Plantilla
                plantilla.resolverPlantilla(entorno, obj)
            End If
        Next
    End Sub


End Class
