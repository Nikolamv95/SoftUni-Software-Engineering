function toggle() {
    let moreText = document.getElementById('extra');
    let buttonTxt = document.getElementsByClassName('button')[0];

    if (moreText.style.display === 'block') {
        buttonTxt.innerHTML = 'More';
        moreText.style.display = 'none';
    } else {
        buttonTxt.innerHTML = 'Less';
        moreText.style.display = 'block';
    }
}

// or

function toogle(){
    let button = document.querySelector('.button');
    let divExtra = document.querySelector('#extra');

    const isHidden = button.textContent = 'More';
    
    divExtra.style.display = (isHidden) ? 'block' : 'none';
    button.textContent = isHidden ? 'Less' : 'More';
}