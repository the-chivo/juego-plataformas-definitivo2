fetch('https://dummyjson.com/recipes/1')
.then(res => res.json())
.then(data =>{
console.log(data) 
//nombre pipsa   
const nombre = data.name
const nombreElemento = document.createElement("h1")
nombreElemento.innerText = nombre
document.body.appendChild(nombreElemento)
nombreElemento.style.fontSize = "50px"
//dificultad
const dificultad = data.difficulty
const dificultadElemento = document.createElement("p")
dificultadElemento.innerText = "Dificult : " + dificultad
document.body.appendChild(dificultadElemento)
dificultadElemento.style.fontSize = "24px"
//Titulo ingredientes
const tituloElemento = document.createElement("h1")
tituloElemento.innerText = "Ingredients"
document.body.appendChild(tituloElemento)

//ingredients lista

const listaingredientes = data.ingredients
const listaingredienteselemento = document.createElement("ol")
listaingredientes.forEach( ingrediente => {
    const item = document.createElement("li")
    item.innerText = ingrediente
    listaingredienteselemento.appendChild(item)
});
document.body.appendChild(listaingredienteselemento)
listaingredienteselemento.style.fontSize = "24px"
//pasos titulo
const pasosTitulo = document.createElement("h1")
pasosTitulo.innerText = "instructions"
document.body.appendChild(pasosTitulo)
//Pasos lista
const pasos = data.instructions
const pasosElement = document.createElement("ol")
pasos.forEach(paso => {
    const itemPaso = document.createElement("li")
    itemPaso.innerText = paso
    pasosElement.appendChild(itemPaso)
})
document.body.appendChild(pasosElement)
pasosElement.style.fontSize = "24px"
//imagen
const imagen = data.image
const imagenElement = document.createElement("img")
imagenElement.src = imagen
document.body.appendChild(imagenElement)
imagenElement.style.width = "720px" 
imagenElement.style.height = "auto"
// Tiempo de preparacion
const preparacion = data.prepTimeMinutes
const preparacionElement = document.createElement("p")
preparacionElement.innerText = "Preparation time : " + preparacion + " min"
document.body.appendChild(preparacionElement)
preparacionElement.style.fontSize = "24px"
//Tiempo de horno
const horno = data.cookTimeMinutes
const hornoElement = document.createElement("p")
hornoElement.innerText = "Cook time minutes: " + horno + "min"
document.body.appendChild(hornoElement)
hornoElement.style.fontSize = "24px"
});









