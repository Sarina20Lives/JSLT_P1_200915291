﻿'Generated by the GOLD Parser Builder

Option Explicit On
Option Strict Off

Imports System.IO
Imports System.Windows.Forms;


Module MyParser
    Private Parser As New GOLD.Parser

    Private Enum SymbolIndex
        [Eof] = 0                                 ' (EOF)
        [Error] = 1                               ' (Error)
        [Whitespace] = 2                          ' Whitespace
        [Minus] = 3                               ' '-'
        [Minusminus] = 4                          ' '--'
        [Exclam] = 5                              ' '!'
        [Exclamampamp] = 6                        ' '!&&'
        [Exclampipepipe] = 7                      ' '!||'
        [Exclam¡] = 8                             ' '!¡'
        [Exclameq] = 9                            ' '!='
        [Percent] = 10                            ' '%'
        [Ampamp] = 11                             ' '&&'
        [Amppipe] = 12                            ' '&|'
        [Ampgt] = 13                              ' '&gt'
        [Ampgte] = 14                             ' '&gte'
        [Amplt] = 15                              ' '&lt'
        [Amplte] = 16                             ' '&lte'
        [Times] = 17                              ' '*'
        [Comma] = 18                              ' ','
        [Divgt] = 19                              ' '/>'
        [Colon] = 20                              ' ':'
        [At] = 21                                 ' '@'
        [Atat] = 22                               ' '@@'
        [Lbracket] = 23                           ' '['
        [Rbracket] = 24                           ' ']'
        [Caret] = 25                              ' '^'
        [Lbrace] = 26                             ' '{'
        [Pipepipe] = 27                           ' '||'
        [Rbrace] = 28                             ' '}'
        [Plus] = 29                               ' '+'
        [Plusplus] = 30                           ' '++'
        [Ltdivbgt] = 31                           ' '</b>'
        [Ltdivbodygt] = 32                        ' '</body>'
        [Ltdivh1gt] = 33                          ' '</h1>'
        [Ltdivh2gt] = 34                          ' '</h2>'
        [Ltdivh3gt] = 35                          ' '</h3>'
        [Ltdivh4gt] = 36                          ' '</h4>'
        [Ltdivh5gt] = 37                          ' '</h5>'
        [Ltdivh6gt] = 38                          ' '</h6>'
        [Ltdivheadgt] = 39                        ' '</head>'
        [Ltdivhtmlgt] = 40                        ' '</html>'
        [Ltdivigt] = 41                           ' '</i>'
        [Ltdivjslcoloncualquierminusotrogt] = 42  ' '</jsl:cualquier-otro>'
        [Ltdivjslcolondegt] = 43                  ' '</jsl:de>'
        [Ltdivjslcolonenminuscasogt] = 44         ' '</jsl:en-caso>'
        [Ltdivjslcolonfinalgt] = 45               ' '</jsl:final>'
        [Ltdivjslcolonifgt] = 46                  ' '</jsl:if>'
        [Ltdivjslcolonparaminuscadagt] = 47       ' '</jsl:para-cada>'
        [Ltdivjslcolonplantillagt] = 48           ' '</jsl:plantilla>'
        [Ltdivpgt] = 49                           ' '</p>'
        [Ltdivtablegt] = 50                       ' '</table>'
        [Ltdivtdgt] = 51                          ' '</td>'
        [Ltdivthgt] = 52                          ' '</th>'
        [Ltdivtitlegt] = 53                       ' '</title>'
        [Ltdivtrgt] = 54                          ' '</tr>'
        [Ltbgt] = 55                              ' '<b>'
        [Ltbodygt] = 56                           ' '<body>'
        [Lth1gt] = 57                             ' '<h1>'
        [Lth2gt] = 58                             ' '<h2>'
        [Lth3gt] = 59                             ' '<h3>'
        [Lth4gt] = 60                             ' '<h4>'
        [Lth5gt] = 61                             ' '<h5>'
        [Lth6gt] = 62                             ' '<h6>'
        [Ltheadgt] = 63                           ' '<head>'
        [Lthtmlgt] = 64                           ' '<html>'
        [Ltigt] = 65                              ' '<i>'
        [Ltjslcolonasignar] = 66                  ' '<jsl:asignar'
        [Ltjslcoloncualquierminusotrogt] = 67     ' '<jsl:cualquier-otro>'
        [Ltjslcolonde] = 68                       ' '<jsl:de'
        [Ltjslcolonenminuscasogt] = 69            ' '<jsl:en-caso>'
        [Ltjslcolonif] = 70                       ' '<jsl:if'
        [Ltjslcolonparaminuscada] = 71            ' '<jsl:para-cada'
        [Ltjslcolonplantilla] = 72                ' '<jsl:plantilla'
        [Ltjslcolonplantillaminusaplicar] = 73    ' '<jsl:plantilla-aplicar'
        [Ltjslcolontransformacion] = 74           ' '<jsl:transformacion'
        [Ltjslcolonvalorminusde] = 75             ' '<jsl:valor-de'
        [Ltjslcolonvariable] = 76                 ' '<jsl:variable'
        [Ltpgt] = 77                              ' '<p>'
        [Lttable] = 78                            ' '<table'
        [Lttd] = 79                               ' '<td'
        [Ltth] = 80                               ' '<th'
        [Lttitlegt] = 81                          ' '<title>'
        [Lttr] = 82                               ' '<tr'
        [Eq] = 83                                 ' '='
        [Eqeq] = 84                               ' '=='
        [Gt] = 85                                 ' '>'
        [Bgcolor] = 86                            ' bgcolor
        [Boolean] = 87                            ' boolean
        [Border] = 88                             ' border
        [Cadena] = 89                             ' cadena
        [Caracter] = 90                           ' CARACTER
        [Condicion] = 91                          ' condicion
        [Div] = 92                                ' div
        [Doble] = 93                              ' DOBLE
        [Entero] = 94                             ' ENTERO
        [False] = 95                              ' false
        [Height] = 96                             ' height
        [Id] = 97                                 ' ID
        [Nombreobj] = 98                          ' nombreObj
        [Ruta] = 99                               ' ruta
        [Seleccionar] = 100                       ' seleccionar
        [String] = 101                            ' STRING
        [True] = 102                              ' true
        [Valor] = 103                             ' valor
        [Variable] = 104                          ' variable
        [Version] = 105                           ' version
        [Width] = 106                             ' width
        [Aplantilla] = 107                        ' <aplantilla>
        [Arit1] = 108                             ' <arit1>
        [Arit2] = 109                             ' <arit2>
        [Arit3] = 110                             ' <arit3>
        [Array] = 111                             ' <array>
        [Asignacion] = 112                        ' <asignacion>
        [Atributo] = 113                          ' <atributo>
        [Atributos] = 114                         ' <atributos>
        [Caso] = 115                              ' <caso>
        [Casos] = 116                             ' <casos>
        [Column] = 117                            ' <column>
        [Columns] = 118                           ' <columns>
        [Cuerpo] = 119                            ' <cuerpo>
        [Declaracion] = 120                       ' <declaracion>
        [Default] = 121                           ' <default>
        [Dimensiones] = 122                       ' <dimensiones>
        [Expresion] = 123                         ' <expresion>
        [Fila] = 124                              ' <fila>
        [Filas] = 125                             ' <filas>
        [For] = 126                               ' <for>
        [Getval] = 127                            ' <getval>
        [Html] = 128                              ' <html>
        [If] = 129                                ' <if>
        [Jslt] = 130                              ' <jslt>
        [Json] = 131                              ' <json>
        [Lenguaje] = 132                          ' <lenguaje>
        [Ljson] = 133                             ' <ljson>
        [Log1] = 134                              ' <log1>
        [Log2] = 135                              ' <log2>
        [Log3] = 136                              ' <log3>
        [Lstring] = 137                           ' <lstring>
        [Numero] = 138                            ' <numero>
        [Obj] = 139                               ' <obj>
        [Plantilla] = 140                         ' <plantilla>
        [Proper] = 141                            ' <proper>
        [Propers] = 142                           ' <propers>
        [Rel] = 143                               ' <rel>
        [Ruta2] = 144                             ' <ruta>
        [Sentencia] = 145                         ' <sentencia>
        [Sentencias] = 146                        ' <sentencias>
        [Switch] = 147                            ' <switch>
        [Tipo] = 148                              ' <tipo>
        [Titulo] = 149                            ' <titulo>
        [Unitario] = 150                          ' <unitario>
        [Val] = 151                               ' <val>
        [Valjson] = 152                           ' <valjson>
        [Var] = 153                               ' <var>
    End Enum

    Private Enum ProductionIndex
        [Lenguaje] = 0                            ' <lenguaje> ::= <json>
        [Lenguaje2] = 1                           ' <lenguaje> ::= <jslt>
        [Json_Lbrace_Rbrace] = 2                  ' <json> ::= '{' <atributos> '}'
        [Atributos_Comma] = 3                     ' <atributos> ::= <atributos> ',' <atributo>
        [Atributos] = 4                           ' <atributos> ::= <atributo>
        [Atributo_String_Colon] = 5               ' <atributo> ::= STRING ':' <valjson>
        [Valjson] = 6                             ' <valjson> ::= <json>
        [Valjson_String] = 7                      ' <valjson> ::= STRING
        [Valjson_Lbracket_Rbracket] = 8           ' <valjson> ::= '[' <array> ']'
        [Array] = 9                               ' <array> ::= <ljson>
        [Array2] = 10                             ' <array> ::= <lstring>
        [Ljson_Comma] = 11                        ' <ljson> ::= <ljson> ',' <json>
        [Ljson] = 12                              ' <ljson> ::= <json>
        [Lstring_Comma_String] = 13               ' <lstring> ::= <lstring> ',' STRING
        [Lstring_String] = 14                     ' <lstring> ::= STRING
        [Jslt_Ltjslcolontransformacion_Ruta_Eq_String_Version_Eq_String_Gt_Ltdivjslcolonfinalgt] = 15 ' <jslt> ::= '<jsl:transformacion' ruta '=' STRING version '=' STRING '>' <cuerpo> '</jsl:final>'
        [Cuerpo] = 16                             ' <cuerpo> ::= <declaracion>
        [Cuerpo2] = 17                            ' <cuerpo> ::= <plantilla>
        [Cuerpo3] = 18                            ' <cuerpo> ::= 
        [Sentencias] = 19                         ' <sentencias> ::= <sentencia> <sentencias>
        [Sentencias2] = 20                        ' <sentencias> ::= 
        [Sentencia] = 21                          ' <sentencia> ::= <declaracion>
        [Sentencia2] = 22                         ' <sentencia> ::= <asignacion>
        [Sentencia3] = 23                         ' <sentencia> ::= <aplantilla>
        [Sentencia4] = 24                         ' <sentencia> ::= <for>
        [Sentencia5] = 25                         ' <sentencia> ::= <if>
        [Sentencia6] = 26                         ' <sentencia> ::= <switch>
        [Sentencia7] = 27                         ' <sentencia> ::= <html>
        [Declaracion_Ltjslcolonvariable_Eq_Divgt] = 28 ' <declaracion> ::= '<jsl:variable' <tipo> '=' <var> '/>'
        [Tipo_Entero] = 29                        ' <tipo> ::= ENTERO
        [Tipo_Cadena] = 30                        ' <tipo> ::= cadena
        [Tipo_Boolean] = 31                       ' <tipo> ::= boolean
        [Tipo_Doble] = 32                         ' <tipo> ::= DOBLE
        [Tipo_Caracter] = 33                      ' <tipo> ::= CARACTER
        [Asignacion_Ltjslcolonasignar_Variable_Eq_Valor_Eq_Divgt] = 34 ' <asignacion> ::= '<jsl:asignar' variable '=' <var> valor '=' <expresion> '/>'
        [Plantilla_Ltjslcolonplantilla_Nombreobj_Eq_Gt_Ltdivjslcolonplantillagt] = 35 ' <plantilla> ::= '<jsl:plantilla' nombreObj '=' <obj> '>' <sentencias> '</jsl:plantilla>'
        [Aplantilla_Ltjslcolonplantillaminusaplicar_Seleccionar_Eq_Divgt] = 36 ' <aplantilla> ::= '<jsl:plantilla-aplicar' seleccionar '=' <obj> '/>'
        [Getval_Ltjslcolonvalorminusde_Seleccionar_Eq_Divgt] = 37 ' <getval> ::= '<jsl:valor-de' seleccionar '=' <obj> '/>'
        [For_Ltjslcolonparaminuscada_Seleccionar_Eq_Gt_Ltdivjslcolonparaminuscadagt] = 38 ' <for> ::= '<jsl:para-cada' seleccionar '=' <obj> '>' <sentencias> '</jsl:para-cada>'
        [If_Ltjslcolonif_Condicion_Eq_Gt_Ltdivjslcolonifgt] = 39 ' <if> ::= '<jsl:if' condicion '=' <expresion> '>' <sentencias> '</jsl:if>'
        [Switch_Ltjslcolonenminuscasogt_Ltdivjslcolonenminuscasogt] = 40 ' <switch> ::= '<jsl:en-caso>' <casos> '</jsl:en-caso>'
        [Casos] = 41                              ' <casos> ::= <caso> <casos>
        [Casos2] = 42                             ' <casos> ::= <default>
        [Casos3] = 43                             ' <casos> ::= <caso>
        [Caso_Ltjslcolonde_Condicion_Eq_Gt_Ltdivjslcolondegt] = 44 ' <caso> ::= '<jsl:de' condicion '=' <expresion> '>' <sentencias> '</jsl:de>'
        [Default_Ltjslcoloncualquierminusotrogt_Ltdivjslcoloncualquierminusotrogt] = 45 ' <default> ::= '<jsl:cualquier-otro>' <sentencias> '</jsl:cualquier-otro>'
        [Var_Id_Lbracket_Rbracket] = 46           ' <var> ::= ID '[' <dimensiones> ']'
        [Var_Id] = 47                             ' <var> ::= ID
        [Dimensiones_Comma] = 48                  ' <dimensiones> ::= <dimensiones> ',' <expresion>
        [Dimensiones] = 49                        ' <dimensiones> ::= <expresion>
        [Obj] = 50                                ' <obj> ::= <var> <ruta>
        [Obj_Atat] = 51                           ' <obj> ::= '@@' <var> <ruta>
        [Obj_At] = 52                             ' <obj> ::= '@' <var> <ruta>
        [Obj_At2] = 53                            ' <obj> ::= '@'
        [Ruta_At] = 54                            ' <ruta> ::= '@' <var> <ruta>
        [Ruta_Atat] = 55                          ' <ruta> ::= '@@' <var> <ruta>
        [Ruta] = 56                               ' <ruta> ::= 
        [Expresion] = 57                          ' <expresion> ::= <log1>
        [Log1_Pipepipe] = 58                      ' <log1> ::= <log1> '||' <log2>
        [Log1_Exclampipepipe] = 59                ' <log1> ::= <log1> '!||' <log2>
        [Log1_Amppipe] = 60                       ' <log1> ::= <log1> '&|' <log2>
        [Log1] = 61                               ' <log1> ::= <log2>
        [Log2_Ampamp] = 62                        ' <log2> ::= <log2> '&&' <log3>
        [Log2_Exclamampamp] = 63                  ' <log2> ::= <log2> '!&&' <log3>
        [Log2] = 64                               ' <log2> ::= <log3>
        [Log3_Exclam] = 65                        ' <log3> ::= '!' <rel>
        [Log3] = 66                               ' <log3> ::= <rel>
        [Rel_Eqeq] = 67                           ' <rel> ::= <rel> '==' <arit1>
        [Rel_Exclameq] = 68                       ' <rel> ::= <rel> '!=' <arit1>
        [Rel_Amplt] = 69                          ' <rel> ::= <rel> '&lt' <arit1>
        [Rel_Amplte] = 70                         ' <rel> ::= <rel> '&lte' <arit1>
        [Rel_Ampgt] = 71                          ' <rel> ::= <rel> '&gt' <arit1>
        [Rel_Ampgte] = 72                         ' <rel> ::= <rel> '&gte' <arit1>
        [Rel] = 73                                ' <rel> ::= <arit1>
        [Arit1_Plus] = 74                         ' <arit1> ::= <arit1> '+' <arit2>
        [Arit1_Minus] = 75                        ' <arit1> ::= <arit1> '-' <arit2>
        [Arit1] = 76                              ' <arit1> ::= <arit2>
        [Arit2_Times] = 77                        ' <arit2> ::= <arit2> '*' <arit3>
        [Arit2_Div] = 78                          ' <arit2> ::= <arit2> div <arit3>
        [Arit2_Percent] = 79                      ' <arit2> ::= <arit2> '%' <arit3>
        [Arit2] = 80                              ' <arit2> ::= <arit3>
        [Arit3_Caret] = 81                        ' <arit3> ::= <arit3> '^' <unitario>
        [Arit3] = 82                              ' <arit3> ::= <unitario>
        [Unitario] = 83                           ' <unitario> ::= <getval>
        [Unitario_Exclam¡] = 84                   ' <unitario> ::= '!¡' <var>
        [Unitario_Plusplus] = 85                  ' <unitario> ::= '++' <var>
        [Unitario_Minusminus] = 86                ' <unitario> ::= '--' <var>
        [Unitario_Plusplus2] = 87                 ' <unitario> ::= <var> '++'
        [Unitario_Minusminus2] = 88               ' <unitario> ::= <var> '--'
        [Unitario2] = 89                          ' <unitario> ::= <var>
        [Unitario3] = 90                          ' <unitario> ::= <val>
        [Val_Caracter] = 91                       ' <val> ::= CARACTER
        [Val_String] = 92                         ' <val> ::= STRING
        [Val_Minus] = 93                          ' <val> ::= '-' <numero>
        [Val] = 94                                ' <val> ::= <numero>
        [Val_True] = 95                           ' <val> ::= true
        [Val_False] = 96                          ' <val> ::= false
        [Numero_Entero] = 97                      ' <numero> ::= ENTERO
        [Numero_Doble] = 98                       ' <numero> ::= DOBLE
        [Html_Lthtmlgt_Ltdivhtmlgt] = 99          ' <html> ::= '<html>' <sentencias> '</html>'
        [Html_Ltbodygt_Ltdivbodygt] = 100         ' <html> ::= '<body>' <sentencias> '</body>'
        [Html_Ltheadgt_Ltdivheadgt] = 101         ' <html> ::= '<head>' <titulo> '</head>'
        [Html_Lth1gt_Ltdivh1gt] = 102             ' <html> ::= '<h1>' <sentencias> '</h1>'
        [Html_Lth2gt_Ltdivh2gt] = 103             ' <html> ::= '<h2>' <sentencias> '</h2>'
        [Html_Lth3gt_Ltdivh3gt] = 104             ' <html> ::= '<h3>' <sentencias> '</h3>'
        [Html_Lth4gt_Ltdivh4gt] = 105             ' <html> ::= '<h4>' <sentencias> '</h4>'
        [Html_Lth5gt_Ltdivh5gt] = 106             ' <html> ::= '<h5>' <sentencias> '</h5>'
        [Html_Lth6gt_Ltdivh6gt] = 107             ' <html> ::= '<h6>' <sentencias> '</h6>'
        [Html_Lttable_Ltdivtablegt] = 108         ' <html> ::= '<table' <propers> <filas> '</table>'
        [Html_Ltpgt_Ltdivpgt] = 109               ' <html> ::= '<p>' <sentencias> '</p>'
        [Html_Ltbgt_Ltdivbgt] = 110               ' <html> ::= '<b>' <sentencias> '</b>'
        [Html_Ltigt_Ltdivigt] = 111               ' <html> ::= '<i>' <sentencias> '</i>'
        [Titulo_Lttitlegt_Ltdivtitlegt] = 112     ' <titulo> ::= '<title>' <sentencias> '</title>'
        [Titulo] = 113                            ' <titulo> ::= <sentencias>
        [Filas] = 114                             ' <filas> ::= <filas> <fila>
        [Filas2] = 115                            ' <filas> ::= <fila>
        [Fila_Lttr_Ltdivtrgt] = 116               ' <fila> ::= '<tr' <propers> <columns> '</tr>'
        [Columns] = 117                           ' <columns> ::= <columns> <column>
        [Columns2] = 118                          ' <columns> ::= <column>
        [Column_Ltth_Ltdivthgt] = 119             ' <column> ::= '<th' <propers> <sentencias> '</th>'
        [Column_Lttd_Ltdivtdgt] = 120             ' <column> ::= '<td' <propers> <sentencias> '</td>'
        [Propers] = 121                           ' <propers> ::= <proper> <propers>
        [Propers_Gt] = 122                        ' <propers> ::= '>'
        [Proper_Border_Eq_String] = 123           ' <proper> ::= border '=' STRING
        [Proper_Bgcolor_Eq_String] = 124          ' <proper> ::= bgcolor '=' STRING
        [Proper_Width_Eq_String] = 125            ' <proper> ::= width '=' STRING
        [Proper_Height_Eq_String] = 126           ' <proper> ::= height '=' STRING
    End Enum

    Public Program As Object     'You might derive a specific object

    Public Sub Setup()
        'This procedure can be called to load the parse tables. The class can
        'read tables using a BinaryReader.
        
        Parser.LoadTables(Path.Combine(Application.StartupPath, "grammar.egt"))
    End Sub
    
    Public Function Parse(ByVal Reader As TextReader) As Boolean
        'This procedure starts the GOLD Parser Engine and handles each of the
        'messages it returns. Each time a reduction is made, you can create new
        'custom object and reassign the .CurrentReduction property. Otherwise, 
        'the system will use the Reduction object that was returned.
        '
        'The resulting tree will be a pure representation of the language 
        'and will be ready to implement.

        Dim Response As GOLD.ParseMessage
        Dim Done as Boolean                  'Controls when we leave the loop
        Dim Accepted As Boolean = False      'Was the parse successful?

        Accepted = False    'Unless the program is accepted by the parser

        Parser.Open(Reader)
        Parser.TrimReductions = False  'Please read about this feature before enabling  

        Done = False
        Do Until Done
            Response = Parser.Parse()

            Select Case Response              
                Case GOLD.ParseMessage.LexicalError
                    'Cannot recognize token
                    Done = True

                Case GOLD.ParseMessage.SyntaxError
                    'Expecting a different token
                    Done = True

                Case GOLD.ParseMessage.Reduction
                    'Create a customized object to store the reduction
                    .CurrentReduction = CreateNewObject(Parser.CurrentReduction)

                Case GOLD.ParseMessage.Accept
                    'Accepted!
                    'Program = Parser.CurrentReduction  'The root node!                 
                    Done = True
                    Accepted = True

                Case GOLD.ParseMessage.TokenRead
                    'You don't have to do anything here.

                Case GOLD.ParseMessage.InternalError
                    'INTERNAL ERROR! Something is horribly wrong.
                    Done = True

                Case GOLD.ParseMessage.NotLoadedError
                    'This error occurs if the CGT was not loaded.                   
                    Done = True

                Case GOLD.ParseMessage.GroupError 
                    'COMMENT ERROR! Unexpected end of file
                    Done = True
            End Select
        Loop

        Return Accepted
    End Function

    Private Function CreateNewObject(Reduction as GOLD.Reduction) As Object
        Dim Result As Object = Nothing

        With Reduction
            Select Case .Parent.TableIndex                        
                Case ProductionIndex.Lenguaje                 
                    ' <lenguaje> ::= <json> 

                Case ProductionIndex.Lenguaje2                 
                    ' <lenguaje> ::= <jslt> 

                Case ProductionIndex.Json_Lbrace_Rbrace                 
                    ' <json> ::= '{' <atributos> '}' 

                Case ProductionIndex.Atributos_Comma                 
                    ' <atributos> ::= <atributos> ',' <atributo> 

                Case ProductionIndex.Atributos                 
                    ' <atributos> ::= <atributo> 

                Case ProductionIndex.Atributo_String_Colon                 
                    ' <atributo> ::= STRING ':' <valjson> 

                Case ProductionIndex.Valjson                 
                    ' <valjson> ::= <json> 

                Case ProductionIndex.Valjson_String                 
                    ' <valjson> ::= STRING 

                Case ProductionIndex.Valjson_Lbracket_Rbracket                 
                    ' <valjson> ::= '[' <array> ']' 

                Case ProductionIndex.Array                 
                    ' <array> ::= <ljson> 

                Case ProductionIndex.Array2                 
                    ' <array> ::= <lstring> 

                Case ProductionIndex.Ljson_Comma                 
                    ' <ljson> ::= <ljson> ',' <json> 

                Case ProductionIndex.Ljson                 
                    ' <ljson> ::= <json> 

                Case ProductionIndex.Lstring_Comma_String                 
                    ' <lstring> ::= <lstring> ',' STRING 

                Case ProductionIndex.Lstring_String                 
                    ' <lstring> ::= STRING 

                Case ProductionIndex.Jslt_Ltjslcolontransformacion_Ruta_Eq_String_Version_Eq_String_Gt_Ltdivjslcolonfinalgt                 
                    ' <jslt> ::= '<jsl:transformacion' ruta '=' STRING version '=' STRING '>' <cuerpo> '</jsl:final>' 

                Case ProductionIndex.Cuerpo                 
                    ' <cuerpo> ::= <declaracion> 

                Case ProductionIndex.Cuerpo2                 
                    ' <cuerpo> ::= <plantilla> 

                Case ProductionIndex.Cuerpo3                 
                    ' <cuerpo> ::=  

                Case ProductionIndex.Sentencias                 
                    ' <sentencias> ::= <sentencia> <sentencias> 

                Case ProductionIndex.Sentencias2                 
                    ' <sentencias> ::=  

                Case ProductionIndex.Sentencia                 
                    ' <sentencia> ::= <declaracion> 

                Case ProductionIndex.Sentencia2                 
                    ' <sentencia> ::= <asignacion> 

                Case ProductionIndex.Sentencia3                 
                    ' <sentencia> ::= <aplantilla> 

                Case ProductionIndex.Sentencia4                 
                    ' <sentencia> ::= <for> 

                Case ProductionIndex.Sentencia5                 
                    ' <sentencia> ::= <if> 

                Case ProductionIndex.Sentencia6                 
                    ' <sentencia> ::= <switch> 

                Case ProductionIndex.Sentencia7                 
                    ' <sentencia> ::= <html> 

                Case ProductionIndex.Declaracion_Ltjslcolonvariable_Eq_Divgt                 
                    ' <declaracion> ::= '<jsl:variable' <tipo> '=' <var> '/>' 

                Case ProductionIndex.Tipo_Entero                 
                    ' <tipo> ::= ENTERO 

                Case ProductionIndex.Tipo_Cadena                 
                    ' <tipo> ::= cadena 

                Case ProductionIndex.Tipo_Boolean                 
                    ' <tipo> ::= boolean 

                Case ProductionIndex.Tipo_Doble                 
                    ' <tipo> ::= DOBLE 

                Case ProductionIndex.Tipo_Caracter                 
                    ' <tipo> ::= CARACTER 

                Case ProductionIndex.Asignacion_Ltjslcolonasignar_Variable_Eq_Valor_Eq_Divgt                 
                    ' <asignacion> ::= '<jsl:asignar' variable '=' <var> valor '=' <expresion> '/>' 

                Case ProductionIndex.Plantilla_Ltjslcolonplantilla_Nombreobj_Eq_Gt_Ltdivjslcolonplantillagt                 
                    ' <plantilla> ::= '<jsl:plantilla' nombreObj '=' <obj> '>' <sentencias> '</jsl:plantilla>' 

                Case ProductionIndex.Aplantilla_Ltjslcolonplantillaminusaplicar_Seleccionar_Eq_Divgt                 
                    ' <aplantilla> ::= '<jsl:plantilla-aplicar' seleccionar '=' <obj> '/>' 

                Case ProductionIndex.Getval_Ltjslcolonvalorminusde_Seleccionar_Eq_Divgt                 
                    ' <getval> ::= '<jsl:valor-de' seleccionar '=' <obj> '/>' 

                Case ProductionIndex.For_Ltjslcolonparaminuscada_Seleccionar_Eq_Gt_Ltdivjslcolonparaminuscadagt                 
                    ' <for> ::= '<jsl:para-cada' seleccionar '=' <obj> '>' <sentencias> '</jsl:para-cada>' 

                Case ProductionIndex.If_Ltjslcolonif_Condicion_Eq_Gt_Ltdivjslcolonifgt                 
                    ' <if> ::= '<jsl:if' condicion '=' <expresion> '>' <sentencias> '</jsl:if>' 

                Case ProductionIndex.Switch_Ltjslcolonenminuscasogt_Ltdivjslcolonenminuscasogt                 
                    ' <switch> ::= '<jsl:en-caso>' <casos> '</jsl:en-caso>' 

                Case ProductionIndex.Casos                 
                    ' <casos> ::= <caso> <casos> 

                Case ProductionIndex.Casos2                 
                    ' <casos> ::= <default> 

                Case ProductionIndex.Casos3                 
                    ' <casos> ::= <caso> 

                Case ProductionIndex.Caso_Ltjslcolonde_Condicion_Eq_Gt_Ltdivjslcolondegt                 
                    ' <caso> ::= '<jsl:de' condicion '=' <expresion> '>' <sentencias> '</jsl:de>' 

                Case ProductionIndex.Default_Ltjslcoloncualquierminusotrogt_Ltdivjslcoloncualquierminusotrogt                 
                    ' <default> ::= '<jsl:cualquier-otro>' <sentencias> '</jsl:cualquier-otro>' 

                Case ProductionIndex.Var_Id_Lbracket_Rbracket                 
                    ' <var> ::= ID '[' <dimensiones> ']' 

                Case ProductionIndex.Var_Id                 
                    ' <var> ::= ID 

                Case ProductionIndex.Dimensiones_Comma                 
                    ' <dimensiones> ::= <dimensiones> ',' <expresion> 

                Case ProductionIndex.Dimensiones                 
                    ' <dimensiones> ::= <expresion> 

                Case ProductionIndex.Obj                 
                    ' <obj> ::= <var> <ruta> 

                Case ProductionIndex.Obj_Atat                 
                    ' <obj> ::= '@@' <var> <ruta> 

                Case ProductionIndex.Obj_At                 
                    ' <obj> ::= '@' <var> <ruta> 

                Case ProductionIndex.Obj_At2                 
                    ' <obj> ::= '@' 

                Case ProductionIndex.Ruta_At                 
                    ' <ruta> ::= '@' <var> <ruta> 

                Case ProductionIndex.Ruta_Atat                 
                    ' <ruta> ::= '@@' <var> <ruta> 

                Case ProductionIndex.Ruta                 
                    ' <ruta> ::=  

                Case ProductionIndex.Expresion                 
                    ' <expresion> ::= <log1> 

                Case ProductionIndex.Log1_Pipepipe                 
                    ' <log1> ::= <log1> '||' <log2> 

                Case ProductionIndex.Log1_Exclampipepipe                 
                    ' <log1> ::= <log1> '!||' <log2> 

                Case ProductionIndex.Log1_Amppipe                 
                    ' <log1> ::= <log1> '&|' <log2> 

                Case ProductionIndex.Log1                 
                    ' <log1> ::= <log2> 

                Case ProductionIndex.Log2_Ampamp                 
                    ' <log2> ::= <log2> '&&' <log3> 

                Case ProductionIndex.Log2_Exclamampamp                 
                    ' <log2> ::= <log2> '!&&' <log3> 

                Case ProductionIndex.Log2                 
                    ' <log2> ::= <log3> 

                Case ProductionIndex.Log3_Exclam                 
                    ' <log3> ::= '!' <rel> 

                Case ProductionIndex.Log3                 
                    ' <log3> ::= <rel> 

                Case ProductionIndex.Rel_Eqeq                 
                    ' <rel> ::= <rel> '==' <arit1> 

                Case ProductionIndex.Rel_Exclameq                 
                    ' <rel> ::= <rel> '!=' <arit1> 

                Case ProductionIndex.Rel_Amplt                 
                    ' <rel> ::= <rel> '&lt' <arit1> 

                Case ProductionIndex.Rel_Amplte                 
                    ' <rel> ::= <rel> '&lte' <arit1> 

                Case ProductionIndex.Rel_Ampgt                 
                    ' <rel> ::= <rel> '&gt' <arit1> 

                Case ProductionIndex.Rel_Ampgte                 
                    ' <rel> ::= <rel> '&gte' <arit1> 

                Case ProductionIndex.Rel                 
                    ' <rel> ::= <arit1> 

                Case ProductionIndex.Arit1_Plus                 
                    ' <arit1> ::= <arit1> '+' <arit2> 

                Case ProductionIndex.Arit1_Minus                 
                    ' <arit1> ::= <arit1> '-' <arit2> 

                Case ProductionIndex.Arit1                 
                    ' <arit1> ::= <arit2> 

                Case ProductionIndex.Arit2_Times                 
                    ' <arit2> ::= <arit2> '*' <arit3> 

                Case ProductionIndex.Arit2_Div                 
                    ' <arit2> ::= <arit2> div <arit3> 

                Case ProductionIndex.Arit2_Percent                 
                    ' <arit2> ::= <arit2> '%' <arit3> 

                Case ProductionIndex.Arit2                 
                    ' <arit2> ::= <arit3> 

                Case ProductionIndex.Arit3_Caret                 
                    ' <arit3> ::= <arit3> '^' <unitario> 

                Case ProductionIndex.Arit3                 
                    ' <arit3> ::= <unitario> 

                Case ProductionIndex.Unitario                 
                    ' <unitario> ::= <getval> 

                Case ProductionIndex.Unitario_Exclam¡                 
                    ' <unitario> ::= '!¡' <var> 

                Case ProductionIndex.Unitario_Plusplus                 
                    ' <unitario> ::= '++' <var> 

                Case ProductionIndex.Unitario_Minusminus                 
                    ' <unitario> ::= '--' <var> 

                Case ProductionIndex.Unitario_Plusplus2                 
                    ' <unitario> ::= <var> '++' 

                Case ProductionIndex.Unitario_Minusminus2                 
                    ' <unitario> ::= <var> '--' 

                Case ProductionIndex.Unitario2                 
                    ' <unitario> ::= <var> 

                Case ProductionIndex.Unitario3                 
                    ' <unitario> ::= <val> 

                Case ProductionIndex.Val_Caracter                 
                    ' <val> ::= CARACTER 

                Case ProductionIndex.Val_String                 
                    ' <val> ::= STRING 

                Case ProductionIndex.Val_Minus                 
                    ' <val> ::= '-' <numero> 

                Case ProductionIndex.Val                 
                    ' <val> ::= <numero> 

                Case ProductionIndex.Val_True                 
                    ' <val> ::= true 

                Case ProductionIndex.Val_False                 
                    ' <val> ::= false 

                Case ProductionIndex.Numero_Entero                 
                    ' <numero> ::= ENTERO 

                Case ProductionIndex.Numero_Doble                 
                    ' <numero> ::= DOBLE 

                Case ProductionIndex.Html_Lthtmlgt_Ltdivhtmlgt                 
                    ' <html> ::= '<html>' <sentencias> '</html>' 

                Case ProductionIndex.Html_Ltbodygt_Ltdivbodygt                 
                    ' <html> ::= '<body>' <sentencias> '</body>' 

                Case ProductionIndex.Html_Ltheadgt_Ltdivheadgt                 
                    ' <html> ::= '<head>' <titulo> '</head>' 

                Case ProductionIndex.Html_Lth1gt_Ltdivh1gt                 
                    ' <html> ::= '<h1>' <sentencias> '</h1>' 

                Case ProductionIndex.Html_Lth2gt_Ltdivh2gt                 
                    ' <html> ::= '<h2>' <sentencias> '</h2>' 

                Case ProductionIndex.Html_Lth3gt_Ltdivh3gt                 
                    ' <html> ::= '<h3>' <sentencias> '</h3>' 

                Case ProductionIndex.Html_Lth4gt_Ltdivh4gt                 
                    ' <html> ::= '<h4>' <sentencias> '</h4>' 

                Case ProductionIndex.Html_Lth5gt_Ltdivh5gt                 
                    ' <html> ::= '<h5>' <sentencias> '</h5>' 

                Case ProductionIndex.Html_Lth6gt_Ltdivh6gt                 
                    ' <html> ::= '<h6>' <sentencias> '</h6>' 

                Case ProductionIndex.Html_Lttable_Ltdivtablegt                 
                    ' <html> ::= '<table' <propers> <filas> '</table>' 

                Case ProductionIndex.Html_Ltpgt_Ltdivpgt                 
                    ' <html> ::= '<p>' <sentencias> '</p>' 

                Case ProductionIndex.Html_Ltbgt_Ltdivbgt                 
                    ' <html> ::= '<b>' <sentencias> '</b>' 

                Case ProductionIndex.Html_Ltigt_Ltdivigt                 
                    ' <html> ::= '<i>' <sentencias> '</i>' 

                Case ProductionIndex.Titulo_Lttitlegt_Ltdivtitlegt                 
                    ' <titulo> ::= '<title>' <sentencias> '</title>' 

                Case ProductionIndex.Titulo                 
                    ' <titulo> ::= <sentencias> 

                Case ProductionIndex.Filas                 
                    ' <filas> ::= <filas> <fila> 

                Case ProductionIndex.Filas2                 
                    ' <filas> ::= <fila> 

                Case ProductionIndex.Fila_Lttr_Ltdivtrgt                 
                    ' <fila> ::= '<tr' <propers> <columns> '</tr>' 

                Case ProductionIndex.Columns                 
                    ' <columns> ::= <columns> <column> 

                Case ProductionIndex.Columns2                 
                    ' <columns> ::= <column> 

                Case ProductionIndex.Column_Ltth_Ltdivthgt                 
                    ' <column> ::= '<th' <propers> <sentencias> '</th>' 

                Case ProductionIndex.Column_Lttd_Ltdivtdgt                 
                    ' <column> ::= '<td' <propers> <sentencias> '</td>' 

                Case ProductionIndex.Propers                 
                    ' <propers> ::= <proper> <propers> 

                Case ProductionIndex.Propers_Gt                 
                    ' <propers> ::= '>' 

                Case ProductionIndex.Proper_Border_Eq_String                 
                    ' <proper> ::= border '=' STRING 

                Case ProductionIndex.Proper_Bgcolor_Eq_String                 
                    ' <proper> ::= bgcolor '=' STRING 

                Case ProductionIndex.Proper_Width_Eq_String                 
                    ' <proper> ::= width '=' STRING 

                Case ProductionIndex.Proper_Height_Eq_String                 
                    ' <proper> ::= height '=' STRING 

            End Select
        End With     

        Return Result
    End Function
End Module
