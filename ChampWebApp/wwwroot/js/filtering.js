const content = document.getElementById("content");

const sortBy = document.getElementById("sort-by");

const sortMode =  document.getElementById("sort-mode");


const accumulation = document.getElementById("acc");

let query = "";
let entity =null;
let mode =null;


class Sort{
    
    query="";
    en = "";
    order = {};
    constructor(sortEntitySelect,sortModeSelect,accumulation=false) {
        this.sortEntitySelect = sortEntitySelect;
        this.sortModeSelect = sortModeSelect;
        this.accumulation = accumulation;
    }
    
    toggleAccumulation(){
        this.accumulation=!this.accumulation;
    }
    getQuery(){
        return this.query;  
    }
    
    listenSelects(fetchCallback,insertOrderTo){
        this.sortEntitySelect.addEventListener("change",(e)=>{
            this.en = e.target.value;
        });
        this.sortModeSelect.addEventListener("change",(e)=>{
            this.setDefaultSelected();
            this.order[this.en]=e.target.value;
            this.buildQuery();
            fetchCallback(insertOrderTo(this.query));
        });
    }
    
    
    setDefaultSelected(){
        if(Object.values(this.order).length===0){
            this.en = this.sortEntitySelect.value;
        }
    }
    
    buildQuery(){
        if(this.accumulation) {
            this.query = "";
            let i = 0;
            const length = Object.keys(this.order).length - 1;
            for (const [key, value] of Object.entries(this.order)) {
                this.query += `${key}:${value}`;
                if (i < length) {
                    this.query += ',';
                    i++;
                }
            }
        }else{
            const key = Object.keys(this.order)[0];
            this.query=`${key}:${this.order[key]}`;
            this.order={};
        }
    }
}



const sort = new Sort(sortBy,sortMode);
sort.listenSelects(fetchSort,sortByFn);


function sortByFn(order){
    return `query{commands{all(order:{${order}}){name,uefaRanking,country {name},coach {fullName}}}}`;
}

accumulation.addEventListener("click",(e)=>{
    if(e.target.classList.contains("bi-check-lg")) {
        e.target.classList.remove("bi-check-lg");
        e.target.classList.remove("hover-green");
        e.target.classList.add("bi-arrow-counterclockwise");
        e.target.classList.add("hover-blue");
    }else{
        e.target.classList.remove("bi-arrow-counterclockwise");
        e.target.classList.remove("hover-blue");
        e.target.classList.add("bi-check-lg");
        e.target.classList.add("hover-green");
    }
    sort.toggleAccumulation();
});


function buildTableBody(commandData){
    content.innerHTML="";
    for(let item of commandData){
        let tr = document.createElement("tr");
        for(const key in item){
            const td = document.createElement("td");
            if(key==="coach"){
                if(item[key]) {
                    td.innerText = item[key].fullName;
                }else{
                    td.innerText="Absent";
                }
                tr.appendChild(td);
                continue;
            }
            if(key==="country"){
                td.innerText = item[key].name;
                tr.appendChild(td);
                continue;
            }
            td.innerText = item[key];
            tr.appendChild(td);
        }
        content.appendChild(tr);
    }
    
}

function fetchSort(query){
    console.log(JSON.stringify(query));
    fetch("http://localhost:5009/graphql",{
        method:"POST",
        headers: {
            'Content-Type': 'application/json',
        },
        body:JSON.stringify({query})
    }).then(res=>res.json())
        .then(data=>{
            buildTableBody(data.data.commands.all);
        });
}

