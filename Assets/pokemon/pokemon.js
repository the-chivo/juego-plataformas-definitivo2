fetch('pokemon?limit=250')
.then(res => res.json())
.then(data => {
console.log(data)
})
console.log(data)