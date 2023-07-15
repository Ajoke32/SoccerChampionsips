const bth = document.getElementById("browse");
const menu = document.getElementById("coach-menu");
const coachExit = document.getElementById("coach-exit");
let query = '';
const form = document.getElementById("form");
const coachInfo = document.getElementById("selected-coach");

const successMessage = document.getElementById("success");
function pagingQuery(first=null,last=null,after=null,before=null){
  
    return `query{coaches {all(first: ${first},last:${last},after:${after},before:${before}){edges{node {id,fullName}},pageInfo {endCursor,hasPreviousPage,hasNextPage,startCursor}}}}`;
}

function createElement(name,classList=null,style=null,id=null,innerText=''){
    const element = document.createElement(name);
    if(classList){element.classList.add(...classList);}
    if(style) {element.style = style.toString();}
    if(id){element.id=id;}
    if(innerText!==''&&innerText){element.innerText=innerText;}
    return element;
}
function getWrap(node) {
    const wrap = createElement("div",["coach-item"]);
    wrap.appendChild(createElement("div",null,null,null,node.fullName));
    const btn = createElement("button",["btn","btn-sm"],"background-color:#70e000;color:#14213d;",null,"Select");
    btn.dataset.id=node.id;
    btn.dataset.name=node.fullName;
    wrap.appendChild(btn);
    return wrap;
}

function setFetchListener(element,after=null,before=null,first=null,last=null){

    element.addEventListener("click",()=>{
        fetchMenu(first,last,after,before); 
    });
}

function disableMove(element){
    element.classList.remove("btn-primary");
    element.classList.add("btn-light");
    element.setAttribute("disabled",true);
}
function exitComponent(){
    const div = createElement("div",null,"align-self:flex-end;position:absolute;")
    div.appendChild(createElement("i",["bi","bi-x-lg","btn","btn-light"],"font-size: 18px;","coach-exit"));
    return div;
}

function fetchMenu(fist=null,last=null,after=null,before=null){
    if(after){after = `"${after}"`;}
    if(before){before=`"${before}"`;}
    query = pagingQuery(fist,last,after,before).toString();
    let next = null;
    fetch("http://localhost:5009/graphql",{
        method:"POST",
        headers: {
            'Content-Type': 'application/json',
        },
        body:JSON.stringify({query})
    }).then(response=>response.json())
        .then(data=>{
            menu.style.display = "flex";
            menu.innerHTML="";
            const exitComp = exitComponent();
            menu.appendChild(exitComp);
            menu.appendChild(createElement("div",null));
            menu.appendChild(createElement("span",['btn'],null,'coach-exit'));
            for(let item of data.data.coaches.all.edges){
                menu.append(getWrap(item.node));
            }
       
            const btgs = createElement("div",null,"display:flex;gap:15px;margin-top:10px;");
            next = createElement("i",['btn','btn-primary','bi','bi-arrow-right'],null,'next')
            const previous = createElement("i",['btn','btn-primary','bi','bi-arrow-left'],null,null);
            btgs.appendChild(previous);
            btgs.appendChild(next);
            menu.appendChild(btgs);
            const pageInfo = data.data.coaches.all.pageInfo;
            const hasNextPage = pageInfo.hasNextPage;
            const hasPreviousPage = pageInfo.hasPreviousPage;
            if(hasNextPage||hasPreviousPage){
                exitComp.addEventListener("click",()=>{
                    menu.style.display="none";
                });
            }
            menu.addEventListener("click",(e)=>{
                const target = e.target;
                if(target.innerText==="Select"){
                    form.elements["CoachId"].value = target.dataset.id.toString();
                    menu.style.display = "none";
                    coachInfo.innerText=target.dataset.name;
                }
            });
            if(hasNextPage){
                const endCursor =pageInfo.endCursor;
                setFetchListener(next,endCursor,null,5,null);
            }else{
                disableMove(next);
            }
            if(hasPreviousPage){
                const startCursor = pageInfo.startCursor;
                setFetchListener(previous,null,startCursor,null,5);
            }else{
                disableMove(previous);
            }
            
        }).catch(e=>{
            console.log(e)
        });
}

bth.addEventListener("click",()=>{
    fetchMenu(5);
});

if(successMessage){
    setTimeout(()=>{
        successMessage.style.display = "none";
    },1500)
}

window.addEventListener("click",(e)=>{
    if(e.target.id!==menu.id&&e.target.id!==bth.id&&!e.target.classList.contains("btn")) {
        menu.style.display = "none";
    }
});