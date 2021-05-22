function solve() { 
    const formElements = document.querySelector('#container').children;
    const inputs = [...formElements].slice(0, formElements.length-1);
    const onScreenBtn = [...formElements][formElements.length-1];
    onScreenBtn.addEventListener('click', createMovie);



    function createMovie(){
        event.preventDefault();
        console.log(create)
    }
}