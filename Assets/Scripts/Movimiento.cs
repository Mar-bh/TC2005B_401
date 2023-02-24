// estamos usando .NET
//aquí "importamos" namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

//Ojo
//con esta directiva obligamos  la  presencia de un comoponente en el gameobject
// (todos tienen transform, el ejemplo es redundante)
[RequireComponent(typeof(Transform))]

public class Movimiento : MonoBehaviour //camel case y empezar por mayúscula
{
    //va  a habersituacionesen dondedeeba acceder a otro componente
    //voy a necesitar una referencia 
    private Transform _transform;

    [SerializeField]
    private float _speed = 5;

    //Ciclo de vida /lifecycle
    //existen métodos que se invocan en momentos específicos de la vida del script

    //Se  invoca una vez al inicio de la vida del componente
    //otra diferencia - awake se invoca aunque el objeto esté deeshabilitado
    void Awake()
    {
        print("AWAKE");
    }

    // Se invnoca una vez despues que fueron invocados todos los awakes
    void Start()
    {
        Debug.Log("START");
        // como obtener referencia a otro componente

        //Notas:
        // - getcomponent es lento, hazlo la menor cantidad de vecees posible
        // - con transform ya tenemos referencia 
        // esta operación puede regresar nulo
        _transform =  GetComponent<Transform>();
        //si tienes require esto ya no es necesario
        Assert.IsNotNull(_transform, "ES NECESARIO PARA MOVIMIENTO TENER UN TRANSFORM");
    }

    // Update is called once per frame
    //Frame, cuadro
    //Fotograma
    //target mínimo  30 fps
    // ideal 60 fps
    void Update()
    {
        // Debug.LogWarning("UPDATE");

        //Siempre vamos a tratar que este sea lo más magro posible
        //Upadte lo usamos para 2 coasa
        //1 - entrada de usuario
        //2 - movimiento

        //Vamos a hacer polling por dispositivo

        //true - cuando en el cuadro anterios estaba libre
        //y en este está presionado
        if (Input.GetKeyDown(KeyCode.Z))
        {
            print("KEY DOWN Z");
        }

        //true - cuando en el cuadro anterior estaba presionado
        //y el actual sigue presionado
          if (Input.GetKey(KeyCode.Z ))
        {
            print("KEY Z");
        }

        //true - estaba presionada
        //ya está libre
        if (Input.GetKeyUp(KeyCode.Z))
        {
            print("KEY UP Z");
        }

        if(Input.GetMouseButtonDown(0))
        {
            print("MOUSE  BUTTON DOWN");
        }

        if(Input.GetMouseButton(0))
        {
            print("MOUSE  BUTTON ");
        }
          if(Input.GetMouseButtonUp(0))
        {
            print("MOUSE  BUTTON Up");
        }

        //vamos a usar ejes
        // - mapeo de hardware a un valor abstracto llamado eje
        // rango de [-1,1]

        // hacemos polling a eje en lugar de hacerlo a hardware  específico
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // print(horizontal+ " " + vertical);

        //se pueden usar ejes como botones
        if(Input.GetButton("Jump"))
        {
            print("JUMP");
        }

        //como mover objetos
        //4 opciones
        //1 - directamente con sus transform
        //2 - por medio del character controller
        //3 - por medio del motor de física
        //4 - por medio de navmesh (AI)

        _transform.Translate(_speed * Time.deltaTime,0,0,Space.World);

    }

    // fixed? - fijo
    //Update que corre en intervalo fijado en la configuración del proyecto
    //No puede correr más frecuentemente que update
    void FixedUpdate()
    {
        //Debug.LogError("FIXED UPDATE");
    }

    //Corre todos los cuadros
    //una vez que los updates están terminados
    void LateUpdate(){
        //print("LATE UPDATE");
    }

    //CODIGO MUY UTIL
    //HOLA ESTOY EN EL REPO
}
