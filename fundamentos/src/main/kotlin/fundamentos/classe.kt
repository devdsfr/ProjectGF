package fundamentos

class Pessoa(var nome: String, var idade: Int){
    override fun toString(): String {
        return "classe: Pessoa. Nome: ${nome}, idade: ${idade}"
    }
}

fun main(){
    var daniel = Pessoa("Daniel", 30)
    println(daniel)
}