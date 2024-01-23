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
- Clases invalidas:
    - Oportunidad de fallo: -1, 101
    - Oportunidad de critico: -1, 101
- Valor esperado: 0 si la tirada da fallo, 1 si no es ni fallo ni critico y 2 si es critico.
### Casos de prueba
|N.Prueba|Oport. fallo|Oport. critico|Devuelve  |
|--------|------------|--------------|----------|
|1       |100         |0             |0         |
|2       |0           |100           |2         |
|3       |0           |0             |1         |
## bool InRange(int checkValue, int smallRangeValue, int bigRangeValue)
### Clases de equivalencia
- Clases validas:
    - Valor a revisar: 5,-5
    - Rango minimo: 2,-4
    - Rango maximo: 4,-2
- Clases invalidas:
    - Valor a revisar: 2147483648
    - Rango minimo: 4
    - Rango maximo: 2
- Valor esperado: Si el valor a revisar esta entre los dos valores, ambos incluidos lanza TRUE si no FALSE
### Casos de prueba
|N.Prueba|Valor a revisar|Valor minimo|Valor maximo|Devuelve|
|--------|---------------|------------|------------|--------|
|1       |100            |100         |100         |TRUE    |
|2       |5              |0           |100         |TRUE    |
|3       |-1             |0           |100         |FALSE   |
|4       |101            |0           |100         |FALSE   |
## bool IsActorAlive(int actorHP)
### Clases de equivalencia
- Clases validas:
    - vida del actor: 55, -123, 0
- Clases no validas:
    - vida del actor: 2147483648,-2147483648
- Valor esperado: Se considera vivo si la salud del personaje esta por encima de 0.
### Casos de prueba
|N.Prueba|HP  |Devuelve|
|--------|----|--------|
|1       |100 |TRUE    |
|2       |0   |FALSE   |
|3       |-100|FALSE   |
## bool AreActorGroupDead(int[] actorsHP)
### Clases de equivalenca
- Clases validas:
    - Vida por actor: 55, -123, 0
- Clases invalidas:
    - Vida por actor: 2147483648,-2147483648
- Valor esperado: Si el array solo contiene la salud de personajes con salud a 0 o negativa se considera true, si al menos uno de ellos tien mas de 0 puntos devolvera FALSE
### Casos de prueba
|N.Prueba|HPs      |Devuelve|
|--------|---------|--------|
|1       |[-1,-100]|TRUE    |
|2       |[0,1]    |FALSE   |
|3       |[-1,1]   |FALSE   |
## int GenerateRandomValue(int minValue, int maxValue)
### Clases de equivalencia
- Clases validas:
    - Valor minimo: 0, -1, 1
    - Valor maximo: 0, -1, 1
- Clases invalidas:
    - Valor minimo: 0, 1
    - valor maximo: -1,-1
- Valor esperado: Un valor aleatorio entre valor minimo y valor maximo donde ambos estan incluidos en el umbral de posibles salidas.
### Casos de prueba
|N.Prueba|Val.Minimo|Val.Maximo|Devuelve|
|--------|----------|----------|--------|
|1       |0         |1         |0 o 1   |
|2       |1         |1         |1       |
## string[] TrimAllStrings(string[] texts)
### Clases de equivalencia
- Clases validas:
    - Textos: "", " ", " Text "
- Clases invalidas:
    - Textos: N/A
- Valor esperado: Un array de strings sin espacios en blanco en ambos extremos de todos los strings en el array
### Casos de prueba
|N.Prueba|Textos          |Devuelve    |
|--------|----------------|------------|
|1       |[" "," Textos "]|["","Textos]|
## string ShowValuesDesc(int[] values, string[] arg, string mainMsg)
### Clases de equivalencia
- Clases validas:
    - Longitud array valores: 4, 1, 0
    - Longitud array argumento: 4, 1, 0
    - Mensaje principal: "Texto{0}{1}","Texto{0}{1}","Texto{0}{1}"
- Clases invalidas:
    - Longitud array valores: 4, 1, 0
    - Longitud array argumento: 1, 0, 4
    - Mensaje principal: "Texto", "Texto{0}", Texto{0}{1}{2}
- Valor esperado: Un string con cada elemento de los dos arrays en el texto del mensaje principal y cada grupo de valores y el mesnaje principal repetido separados por un salto de linea.
### Casos de prueba
|N.Prueba|valores|array de argumento    |Mensaje      |Devuelve                              |
|--------|-------|----------------------|-------------|--------------------------------------|
|1       |[2,5,4]|["Someone","Yes","no"]|"Texto{0}{1}"|"TextoYes5\nTextono4\nTextoSomeone2\n"|
## void ReorderDesc(ref int[] values, ref string[] valuesMsg)
### Clases de equivalencia
- Clases validas:
    - Longitud de valores: 4, 1, 0
    - Longitud de mensaje con valores: 4, 1, 0
- Clases invalidas:
    - Longitud de valores: 0, 4, 1
    - Longitud de  mensaje con valores: 4, 1, 0
- Valor esperado: Los dos arrays ordenados basandose principalmente en valores y de forma descendente.
### Casos de prueba
|N.Prueba|valores|array de argumento    |valores procesado|array de argumento procesado|
|--------|-------|----------------------|-----------------|----------------------------|
|1       |[2,5,4]|["Someone","Yes","no"]|[5,4,2]          |["Yes","no","Someone"]      |