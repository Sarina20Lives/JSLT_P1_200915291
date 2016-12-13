Public Class Transform

    Dim manArch As ManejoArchivos = New ManejoArchivos

    Public Sub resolverTransform(ByVal raiz As Nodo, ByVal directorio As String)
        Dim entorno As Entorno = New Entorno
        Dim plantilla As Plantilla = Nothing
        Dim declarre As Declarar = Nothing

        manArch.escribirHtml("")


        'Construir Ast de JSon
        Dim analisis As Boolean = False
        Dim direccion As String = ""
        Dim raizJsl As Nodo = New Nodo
        Dim raizJson As PtrJson = New PtrJson
        Dim Cadena As System.IO.StringReader = New System.IO.StringReader(manArch.leer(directorio))
        Setup()
        Parse(Cadena, analisis, raizJson, raizJsl, direccion)

        'Seteando el entorno
        entorno.raiz = raizJson

        Dim obj As Nodo
        For Each obj In raiz.hijos
            If (obj.subrol = Constantes.SR_DECLARE) Then
                declarre = New Declarar
                declarre.resolverDeclare(entorno, obj, True)
            End If
            If (obj.subrol = Constantes.SR_PLANTILLA And CType(obj.getHijo(0), Nodo).subrol = Constantes.SR_RAIZ) Then
                plantilla = New Plantilla
                plantilla.resolverPlantilla(entorno, obj)
            End If
        Next
    End Sub


End Class
