# Fruit Catch SMTP
# Integración SMTP en Unity
## Evento que Dispara la Notificación
El evento Game Over ocurre cuando el jugador pierde 3 frutas.
En ese momento se genera dinámicamente el asunto y cuerpo del mensaje
según si se superó el puntaje máximo o no.
1. Obtiene el puntaje actual del jugador.
2. Construye dinámicamente el asunto del correo incluyendo el puntaje.
3. Genera el cuerpo del mensaje describiendo el resultado del juego.
4. Llama el SendMail para realizar el envío.
## Flujo del evento:
GameOver → Generación del mensaje → Envío SMTP → Obtener resultado en correo
## Manejo de Respuestas del Servidor
- Si el envío es exitoso:
  - Se muestra en la interfaz: "Correo enviado correctamente."
- Si ocurre un error (por ejemplo: límite diario excedido, credenciales inválidas o problema de conexión):
  - Se captura la excepción.
  - Se muestra el mensaje de error del servidor en pantalla.
Esto permite visualizar el estado del envío y evidencia la respuesta del servidor SMTP dentro del juego.
