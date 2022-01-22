package fundamentos

import sun.util.locale.StringTokenIterator
import kotlin.concurrent.fixedRateTimer

fun main(){
    dizDi(retornaNome(), idade = 24)
    dizDi(idade = 24, nome = "Gustavo")
    dizDi( nome = "Daniel")
}

fun retornaNome(): String {
    return "Gustavo"
}

fun dizDi(nome: String, idade: Int = 20){
    println("Oi ${nome}, parabêns pels seus ${idade} anos")
}