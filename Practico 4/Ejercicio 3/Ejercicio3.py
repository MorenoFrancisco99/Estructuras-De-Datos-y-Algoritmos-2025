# -*- coding: utf-8 -*-
from typing import Dict, List, Optional


class HuffmanCompresser:
  
    class Nodo:
        def __init__(self, caracter: str = None, frecuencia: int = 0):
            self.caracter: str = caracter
            self.frecuencia: int = frecuencia
            self.izquierdo: HuffmanCompresser.Nodo = None
            self.derecho: HuffmanCompresser.Nodo= None
            self.siguiente: HuffmanCompresser.Nodo = None

    class HuffmanCodes:
        def __init__(self, frecuencia: int = 0, codigo: str = ""):
            self.frecuencia: int = frecuencia
            self.codigo: str = codigo

    def __init__(self):
        # Array de nodos para almacenar la frecuencia de cada caracter ASCII.
        self.listaDeFrecuencias: List[HuffmanCompresser.Nodo] = [self.Nodo() for _ in range(256)]
        # Cabeza de la lista enlazada de nodos para construir el árbol de Huffman.
        self.cabeza: Optional[HuffmanCompresser.Nodo] = None
        # La insercion siempre va a ser al final de la lista. Conviene tener una referencia al ultimo nodo.
        self.ultimo: Optional[HuffmanCompresser.Nodo] = None

        # Tabla de códigos de Huffman para cada caracter.
        self.tablaDeCodigos: Dict[str, HuffmanCompresser.HuffmanCodes] = {}

        self.texto: str = ""

    """
    Codigo en el main para probar HuffmanCompresser

        huffman = HuffmanCompresser()
        texto = "Ejemplo de texto para comprimir utilizando el algoritmo de Huffman."
        huffman.CrearCodigoHuffman(texto)
        huffman.MostrarFrecuenciaDeCaracteres()
        huffman.MostrarTabla()
        huffman.Comprimir()
    """

    def CrearCodigoHuffman(self, texto: str) -> int:
        """
        <summary>
        Genera los códigos de Huffman basados en las frecuencias de los caracteres de un texto cargado. 
        </summary>
        <remarks>
        La insercion de caracteres de control puede causar errores, se recomienda usar texto plano.
        </remarks>
        <returns>
        Tabla de códigos de Huffman para cada caracter.
        </returns>
        """
        if texto is None or texto == "":
            print("Error: El texto proporcionado es nulo o vacío.")
            return -1

        for c in texto:
            self.InsertarArray(c)

        self.texto = texto
        # Ordenamos los nodos por frecuencia
        self.listaDeFrecuencias = self.OrdenarArrayAcendente(self.listaDeFrecuencias)

        if len(self.listaDeFrecuencias) == 0:
            print("Error: No hay caracteres con frecuencia > 0.")
            return -1

        # Construimos la lista enlazada con los nodos ordenados
        self.cabeza = self.listaDeFrecuencias[0]
        self.ultimo = self.cabeza
        for i in range(1, len(self.listaDeFrecuencias)):
            self.ultimo.siguiente = self.listaDeFrecuencias[i]
            self.ultimo = self.ultimo.siguiente

        # Comenzamos a construir el arbol de Huffman
        while self.cabeza is not None and self.cabeza.siguiente is not None:
            primerNodo = self.cabeza
            segundoNodo = self.cabeza.siguiente

            nuevoNodo = self.Nodo(
                caracter=(primerNodo.caracter or "") + (segundoNodo.caracter or ""),
                frecuencia=primerNodo.frecuencia + segundoNodo.frecuencia
            )
            nuevoNodo.izquierdo = primerNodo  # El mas pequeño va a la izquierda
            nuevoNodo.derecho = segundoNodo   # El segundo mas pequeño va a la derecha

            # Avanzamos la cabeza dos posiciones
            # Si no hay más nodos luego de segundoNodo, cabeza quedará en None
            if self.cabeza.siguiente is not None:
                siguiente_despues = self.cabeza.siguiente.siguiente
            else:
                siguiente_despues = None
            self.cabeza = siguiente_despues

            # Insertamos el nuevo nodo en la lista ordenada
            self.InsertarListaOrdenada(nuevoNodo)

        # Ahora cabeza apunta al nodo raiz del arbol de Huffman
        # Reiniciamos la tabla (por si acaso) y generamos códigos
        self.tablaDeCodigos.clear()
        self.GenerarTablaDeCodigos(self.cabeza, "")
        print("Árbol de Huffman construido.")
        return 1

    def Comprimir(self) -> None:
        """
        <summary>
        Convierte el texto original en una secuencia comprimida utilizando los códigos de Huffman generados.
        </summary>
        <returns>
        Un string representando el texto comprimido.
        </returns>
        """
        partes: List[str] = []
        for c in self.texto:
            if c in self.tablaDeCodigos:
                partes.append(self.tablaDeCodigos[c].codigo)
            else:
                print(f"Error: El caracter '{c}' no tiene un código de Huffman asignado.")
                return
        textoComprimido = "".join(partes)
        print(f"Texto comprimido: {textoComprimido}")

    def Descomprimir(self) -> None:
        """
        <summary>
        Extrae el texto original a partir de la secuencia comprimida utilizando los códigos de Huffman.
        </summary>
        <remarks>
        Esta función debe reconstruir el texto original utilizando la tabla de códigos de Huffman.
        </remarks>
        <returns>
        String del texto descomprimido.
        </returns>
        """
        # No implementado
        pass

    def MostrarFrecuenciaDeCaracteres(self) -> None:
        """
        <summary>
        Muestra de la lista los caracteres y sus frecuencias
        </summary>
        """
        print("Caracter (ASCII) : Frecuencia")
        for i in range(len(self.listaDeFrecuencias)):
            nodo = self.listaDeFrecuencias[i]
            if nodo is not None and nodo.frecuencia > 0:
                print(f"   '{nodo.caracter}' ({i}) : {nodo.frecuencia}")

    def MostrarTabla(self) -> None:
        """
        <summary>
        Muestra la tabla de codigos de Huffman
        </summary>
        """
        print("Caracter\t Frecuencia\t Codigo")
        for key, entry in self.tablaDeCodigos.items():
            print(f"   '{key}'\t\t {entry.frecuencia}\t\t {entry.codigo}")

    def GenerarTablaDeCodigos(self, nodo: Optional[Nodo], codigoActual: str) -> None:
        """
        <summary>
        Genera la tabla de caracteres y sus códigos de Huffman a partir del árbol.
        </summary>
        <param name="nodo"></param>
        <param name="codigoActual"></param>
        """
        if nodo is None:
            return
        # Si es una hoja, agregar el código a la tabla
        if nodo.izquierdo is None and nodo.derecho is None:
            # Nota: se asume que nodo.caracter contiene al menos un caracter y que la hoja representa un único caracter
            if nodo.caracter:
                caracter = nodo.caracter[0]
                self.tablaDeCodigos[caracter] = self.HuffmanCodes(frecuencia=nodo.frecuencia, codigo=codigoActual)
            return
        # Recorrer el subárbol izquierdo y derecho
        self.GenerarTablaDeCodigos(nodo.izquierdo, codigoActual + "0")
        self.GenerarTablaDeCodigos(nodo.derecho, codigoActual + "1")

    def InsertarArray(self, caracter: str) -> int:
        """
        <summary>
        Suma 1 a la frecuencia del caracter en su posición correspondiente del array.
        </summary>
        <remarks>
        Convierte el caracter a su valor ASCII y utiliza este valor como índice en el array para incrementar la frecuencia.
        </remarks>
        <param name="caracter"></param>
        <returns></returns>
        """
        try:
            ASCIIvalue = ord(caracter)
            if ASCIIvalue < 0 or ASCIIvalue >= len(self.listaDeFrecuencias):
                raise IndexError("Index fuera de rango ASCII.")
            nodo = self.listaDeFrecuencias[ASCIIvalue]
            nodo.caracter = caracter  # Se repite pero no afecta el resultado
            nodo.frecuencia += 1
        except IndexError:
            print("Error: Caracter fuera del rango ASCII.")
            return -1
        except Exception as ex:
            print(f"Error inesperado: {ex}")
            return -1
        return 1

    def InsertarListaOrdenada(self, nuevoNodo: Nodo) -> int:
        """
        <summary>
        Inserta un nuevo nodo en la lista enlazada manteniendo el orden basado en la frecuencia.
        </summary>
        <param name="nuevoNodo"></param>
        <returns></returns>
        """
        if self.cabeza is None or nuevoNodo.frecuencia < self.cabeza.frecuencia:
            nuevoNodo.siguiente = self.cabeza
            self.cabeza = nuevoNodo
            # si ultimo es None, inicializarlo
            if self.ultimo is None:
                self.ultimo = nuevoNodo
            return 1

        if self.ultimo is not None and self.ultimo.frecuencia <= nuevoNodo.frecuencia:
            self.ultimo.siguiente = nuevoNodo
            self.ultimo = nuevoNodo
            return 1

        actual = self.cabeza
        # avanzamos hasta el punto donde insertar (se mantiene orden ascendente por frecuencia)
        while actual.siguiente is not None and actual.siguiente.frecuencia <= nuevoNodo.frecuencia:
            actual = actual.siguiente

        nuevoNodo.siguiente = actual.siguiente
        actual.siguiente = nuevoNodo
        # ajustar 'ultimo' si fue insertado al final
        if nuevoNodo.siguiente is None:
            self.ultimo = nuevoNodo

        return 1

    def OrdenarArrayAcendente(self, listaAOrdenar: List[Nodo]) -> List[Nodo]:
        """
        <summary>
        Ordena la lista en orden ascendente basado en la frecuencia de los caracteres.\n 
        Debe aplicarse unicamente despues de haber insertado todos los caracteres.
        Los cambios son irreversibles, no se puede volver al orden original y elimina los caracteres con frecuencia 0.
        </summary>
        <remarks>
        Utiliza Bubble Sort para ordenar la lista.
        </remarks>
        <returns></returns>
        """
        filtrada = [nodo for nodo in listaAOrdenar if nodo.frecuencia > 0]
        filtrada.sort(key=lambda x: x.frecuencia)
        return filtrada
