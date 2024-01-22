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
|4       |"Texto"       |["a","b"]       |"Texto"              |
## int CalcAttackDamage(int attackerDamageValue, int targetDefenseValue)
### Clases de equivalencia
- Clases validas:
    - Ataque: 0, 50, 4000
    - Defensa: 0, 100, 50
- Clases invalidas:
    - Ataque: -1
    - Defensa: 20
- Valor esperado: El valor de ataque tras ser reducido por el porcentaje de defensa.
### Casos de prueba
|N.Prueba|Ataque        |Defensa         |Devuelve             |
|--------|--------------|----------------|---------------------|
|1       |0             |0               |0                    |
|2       |50            |100             |0                    |
|3       |4000          |50              |2000                 |
## string AttackOption(int attackerDMG, int targetDefense, ref int targetHP, string msg)
### Clases de equivalencia
- Clases validas:
    - Ataque: 0, 50, 4000
    - Defensa: 0, 100, 50
    - Salud: 1, 1, 1999
    - Mensaje: "Texto{0}{1}{2}", "Texto{0}{1}{2}", "Texto{0}{1}{2}", "Texto{0}{1}{2}"
- Clases invalidas:
    - Ataque: -1
    - Defensa: 20
    - Salud: -1
    - Mensaje: "Texto"
- Valor esperado: Devuelve la cadena de texto de mensaje formateada con los valores del daño infligido, daño proporcionado y la vida restante del valor de salud ademas de actualizar la salud al ser pasado por referencia.
### Casos de prueba
|N.Prueba|Ataque        |Defensa         |Salud|Mensaje         |Devuelve         |Salud alterada|
|--------|--------------|----------------|-----|----------------|-----------------|--------------|
|1       |0             |0               |1    |"Texto{0}{1}{2}"|"Texto001"       |1             |
|2       |50            |100             |1    |"Texto{0}{1}{2}"|"Texto5001"      |1             |
|3       |4000          |50              |1999 |"Texto{0}{1}{2}"|"Texto40002000-1"|-1            |
## void DefenseAction(ref int actorDefense, int newDefenseValue)
### Clases de equivalencia
- Clases validas:
    - Defensa actor: 5,4,100
    - Nueva defensa: 50, 100, 0
- Clases invalidas:
    - Defensa actor: 99999999
    - Defensa: 99999999
- Valor esperado: Sistituir el valor referenciado con el nuevo valor de defensa.
### Casos de prueba
|N.Prueba|Def. actor    |Nueva defensa|Def. actor|
|--------|--------------|-------------|----------|
|1       |0             |4            |4         |
## int HealTarget(int targetHP, int healingAmount, int targetMaxHP)
### Clases de equivalencia
- Clases validas:
    - Vida del objetivo: 1, 100
    - Cantidad de curacion: 1, 200
    - Vida max. del objetivo: 3, 150
- Clases invalidas:
    - Vida del objetivo: -1, 200
    - Cantidad de curacion: -1, 100
    - Vida max. del objetivo: -1 , 100
- Valor esperado: La nueva salud del objetivo el cual no puede sobrepasar su vida maxima
### Casos de prueba
|N.Prueba|Vid. Objetivo |Cant. Sanacion|Vida Max. Ojbetivo |Devuelve |
|--------|--------------|--------------|-------------------|---------|
|1       |5             |4             |10                 |9        |
|2       |5             |5             |6                  |6        |
## int CritFail(int chanceFail, int chanceCrit)
### Clases de equivalencia
- Clases validas:
    - Oportunidad de fallo: 50, 0, 100
    - Oportunidad de critico: 50, 0, 100