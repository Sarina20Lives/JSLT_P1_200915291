Public Class Nodo
    Public rol As Integer = Constantes.ERR
    Public subrol As Integer = Constantes.ERR
    Public tipo As Integer = Constantes.ERR
    Public cad As String = ""
    Public fila As Integer = -1
    Public column As Integer = -1
    Public hijos As ArrayList = New ArrayList


    Public Function crearHTML(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer, ByVal sentencias As Nodo)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_HTML
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        nodo.hijos.Add(sentencias)
        Return nodo
    End Function

    Public Function crearHTML(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer, ByVal sentencias As ArrayList)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_HTML
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        Dim obj As Nodo
        For Each obj In sentencias
            nodo.hijos.Add(obj)
        Next obj
        Return nodo
    End Function

    Public Function crearOperador(ByVal subrol As Integer, ByVal tipo As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_OPERADOR
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        nodo.tipo = tipo
        Return nodo
    End Function

    Public Function crearAritmetica(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer, ByVal op1 As Nodo, ByVal op2 As Nodo)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_ARITMETICA
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        nodo.hijos.Add(op1)
        nodo.hijos.Add(op2)
        Return nodo
    End Function

    Public Function crearAritmetica(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer)
        Dim nodo As Nodo = New Nodo
        Nodo.rol = Constantes.R_ARITMETICA
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        Return nodo
    End Function

    Public Function crearRelacional(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer, ByVal op1 As Nodo, ByVal op2 As Nodo)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_RELACIONAL
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        nodo.hijos.Add(op1)
        nodo.hijos.Add(op2)
        Return nodo
    End Function

    Public Function crearRelacional(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_RELACIONAL
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        Return nodo
    End Function

    Public Function crearLogica(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer, ByVal op1 As Nodo, ByVal op2 As Nodo)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_LOGICA
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        nodo.hijos.Add(op1)
        nodo.hijos.Add(op2)
        Return nodo
    End Function

    Public Function crearLogica(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer, ByVal op1 As Nodo)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_LOGICA
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        nodo.hijos.Add(op1)
        Return nodo
    End Function

    Public Function crearVar(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_VAR
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        Return nodo
    End Function

    Public Function crearArr(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer, ByVal posicion As Nodo)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_ARR
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        nodo.hijos.Add(posicion)
        Return nodo
    End Function

    Public Function crearAcceso(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_ACCESO
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        Return nodo
    End Function

    Public Function crearAcceso()
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_ACCESO
        nodo.subrol = Constantes.SR_RUTA
        nodo.cad = cad
        nodo.hijos = New ArrayList
        Return nodo
    End Function

    Public Function predAcceso(ByVal acceso As Nodo, ByVal nodo As Nodo, ByVal subrol As Integer)
        nodo.subrol = subrol
        acceso.hijos.Insert(0, nodo)
        Return acceso
    End Function

    Public Function pred(ByVal padre As Nodo, ByVal hijo As Nodo)
        padre.hijos.Insert(0, hijo)
        Return padre
    End Function

    Public Function add(ByVal padre As Nodo, ByVal hijo As Nodo)
        padre.hijos.Add(hijo)
        Return padre
    End Function

    Public Function crearJSL(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer, ByVal hijos As ArrayList)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_JSL
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        Dim obj As Nodo
        For Each obj In hijos
            nodo.hijos.Add(obj)
        Next obj
        Return nodo
    End Function

    Public Function crearJSL(ByVal subrol As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer, ByVal hijo As Nodo)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_JSL
        nodo.subrol = subrol
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        nodo.hijos.Add(hijo)
        Return nodo
    End Function

    Public Function crearDeclare(ByVal tipo As Integer, ByVal cad As String, ByVal fila As Integer, ByVal column As Integer)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_JSL
        nodo.subrol = Constantes.SR_DECLARE
        nodo.tipo = tipo
        nodo.cad = cad
        nodo.fila = fila
        nodo.column = column
        Return nodo
    End Function

    Public Function crearJSL(ByVal subrol As Integer)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_JSL
        nodo.subrol = subrol
        Return nodo
    End Function

    Public Function crearJSL(ByVal subrol As Integer, ByVal hijo As Nodo)
        Dim nodo As Nodo = New Nodo
        nodo.rol = Constantes.R_JSL
        nodo.subrol = subrol
        nodo.hijos.Add(hijo)
        Return nodo
    End Function

    Public Function getHijo(ByVal indice As Integer)
        If (indice >= Me.hijos.Count) Then
            Return Nothing
        End If
        Return CType(Me.hijos.Item(indice), Nodo)
    End Function

End Class
