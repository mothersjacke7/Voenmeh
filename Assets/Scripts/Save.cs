using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO; // Используем библиотеку ввода вывода

public class Save : MonoBehaviour {
   
   public string filename; // Путь сохранения
   
   
   void Start () // Данный скрипт выполняется при инициализации объекта.
   {
      if ( filename == "" ) filename = "Data/Save/Position.sg"; 
      // Если название файла не указанно то пишем по умолчанию
   }
   
   void OnGUI () // Создаем ГУИ элементы, текстовое поле и 2 кнопки
   {
      if ( GUI.Button( new Rect(10,10,60,20),"Write") ) // Нажата кнопка "запись"?
      {
         StreamWriter sw = new StreamWriter(filename); // Создаем файл
            sw.WriteLine(transform.position.x); // Пишем координаты
			sw.WriteLine(transform.position.y);
			sw.WriteLine(transform.position.z);
			Debug.Log("Save" + transform.position);
            sw.Close(); // Закрываем(сохраняем)
      }
   }
}