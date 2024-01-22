# Funcionalidades extras
## Puntuacion de agilidad
Los personajes ahora poseen un stat mas, el stat de agilidad el cual va ligado a como el sistema decide el orden de los jugadores.
Cuando el juego intenta decidir el orden hace una tirada entre 0-100 y luego añade la puntuacion de agilidad con una suma asi que si un personaje tira y saca un 40 y tiene 50 de agilidad el resultado final seria 90 y con ese numero se le compararia con los demas para determinar el orden.
# Tests
## string BuildMenu(string[] options, string askmsg)
### Clases de equivalencia
- Clases validas:
    - Array de opciones: [],["a", "b", "c", ...]
    - Mensaje de pregunta: Cualquier cadena de texto.
- Clases invalidas:
    - Array de opciones: NULL
    - Mensaje de pregunta: NULL
- Valor esperado: Una cadena de texto con los valores en el posicionados en la cadena con forma de lista del 1 hasta el final del array de opciones y con el mensaje de pregunta al final de la cadena

### Casos de preuba
|N.Prueba|Array opciones|Mensaje pregunta|Devuelve             |
|--------|--------------|----------------|---------------------|
|1       |["a","b",""]  |"d"             |"1. a\n2. b\n3. \nd" |
|2       |[]            |""              |""                   |
## string BuildMenu(string[] options, string askmsg, string msg)
### Clases de equivalencia
- Clases validas:
    - Array de opciones: [],["a", "b", "c", ...]
    - Mensaje de pregunta: Cualquier cadena de texto.
    - Mensaje: Cualquier cadena de texto
- Clases invalidas:
    - Array de opciones: NULL
    - Mensaje de pregunta: NULL
    - Mensaje: NULL
- Valor esperado: Una cadena de texto con los valores en el posicionados en la cadena con forma de lista, con el mensaje de pregunta al final de la cadena y con el mensaje encima de la lista
### Casos de prueba
|N.Prueba|Array opciones|Mensaje pregunta|Mensaje|Devuelve               |
|--------|--------------|----------------|-------|-----------------------|
|1       |["a","b",""]  |"d"             |"e"    |"e\n1. a\n2. b\n3. \nd"|
|2       |[]            |""              |""     |"\n"                   |
## string FormatString(string text, params string[] args)
### Clases de equivalencia
- Clases validas:
    - Texto: "{0}{1}Texto", "Texto"
    - Argumentos: ["a", "b"],[]
- Clases invalidas:
    - Texto: "{0}{1}Texto", "Texto"
    - Argumentos: [],["a"]
- Valor esperado: Una cadena de texto con los elementos {n} sistituidos con los elementos en argumento.
### Casos de prueba
|N.Prueba|Texto         |Argumentos      |Devuelve             |
|--------|--------------|----------------|---------------------|
|1       |"{0}{1}Texto" |["a","b"]       |"abTexto"            |
|2       |"Texto"       |[]              |"Texto"              |
|3       |"{0}{1}Texto" |[]              |"{0}{1}Texto"        |
|4       
    
