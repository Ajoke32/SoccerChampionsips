
let bth = document.getElementById("get");


const filter = 'where:{email:{eq:"dx"}}';
const query = addFilter(filter);





function addFilter(filter){
    return  `query {users(${filter}){name,email}}`;
}



bth.addEventListener("click",()=>{
    
    fetch("http://localhost:5009/graphql",{
        method:"POST",
        headers: {
            'Content-Type': 'application/json',
        },
        body:JSON.stringify({query})
    }).then(response=>response.json())
        .then(data=>{
            console.log(data)
        }).catch(e=>{
        console.log(e)
        });
});

