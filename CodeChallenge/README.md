
# BairesDev .Net Sr Dev Code Challenge


## Pasos para la resolución:
1. Recorremos el archivo **people.in** y generamos el array de People.
2. Les asignamos un puntaje a cada persona para determinar en qué grado es un potencial cliente o no. En orden de importancia:
	1. Country: Mayor puntaje a aquellos en Latinoamerica.
	2. Role: Buscamos que sea alguien con un rol importante dentro de la empresa.
	3. Industry: Buscamos que sean industrias relacionadas a IT o Software Development.
	4. NumberOfRecommendations: Son mas importantes que las conexiones.
	5. NumberOfConnections: No son tan importantes. 
3. Imprimimos el resultado de los 100 clientes con mayor puntaje al archivo **people.out**


## Posibles mejoras:
1. La ecuación debería ser evaluada para saber si los valores que tiene asignado cada uno de los items es correcto y representa la realidad. Noté que algunos registros dentro del top 100 no deberían estar ahi. 
2. Revisar el sistema de puntaje para evaluar correctamente. Ej: Es más importante que esté en Latinoamerica a que sea el CEO de una empresa en Estados Unidos?.
3. Dejar de depender de un archivo de texto como input y poder leer directamente desde Linkedin.
4. Informar al equipo de ventas de nuevos potenciales clientes via mail o algún sistema de notificaciones.