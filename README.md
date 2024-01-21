# Funcionalidades extras
## Puntuacion de agilidad
Los personajes ahora poseen un stat mas, el stat de agilidad el cual va ligado a como el sistema decide el orden de los jugadores.
Cuando el juego intenta decidir el orden hace una tirada entre 0-100 y luego añade la puntuacion de agilidad con una suma asi que si un personaje tira y saca un 40 y tiene 50 de agilidad el resultado final seria 90 y con ese numero se le compararia con los demas para determinar el orden.
# Tests
## BuildMenu
### Clases de equivalencia
- Clases validas:
    - Array de opciones: [0]-[∞]
        - String: Cualquier cadena de texto.
    - Mensaje de pregunta: Cualquier cadena de texto.
- Clases invalidas:
    - Array de opciones: N/A
        - String: N/A
    - Mensaje de pregunta: N/A
- Valor esperado: Una cadena de texto con los valores en el posicionados en la cadena con forma de lista y con el mensaje de pregunta al final de la cadena

## 