/* globals createElement, game */

Object.assign(window.game, (function () {
    const playerSlot = document.getElementById('player');
    const enemySlot = document.getElementById('enemies');

    const player = game.createCharacter('player');

    const encounterController = game.encounterController(enemySlot, player)

    const controls = createElement('div', { id: 'controls' },
        createElement('button', { onClick: () => encounterController.onPlayerAttack() }, 'Attack')
    );

    disableControls();

    playerSlot.appendChild(player.element);
    playerSlot.appendChild(controls);

    game.events.onBeginTurn.subscribe(onBeginTurn);
    game.events.onEncounterEnd.subscribe(onEncounterEnd);


    let difficalty = 1;
    // Begin encounter as player
    encounterController.enter(game.generateEncounter(difficalty));

    function onBeginTurn(controller) {
        if (controller.character.ai) {
            disableControls();
            setTimeout(() => { }, 500);
            encounterController.onEnemyAttack();
            encounterController.selectTarget({ target: player.element });

        } else {
            enableControls();
        }
    };

    function onEncounterEnd(victory) {
        if (victory) {
            alert('Victory! Game over!')
            difficalty++;
            encounterController.enter(game.generateEncounter(difficalty));
            disableControls();
        } else {
            alert('You died. Game over!')
            disableControls();
        }
    };

    function enableControls() {
        [...controls.children].forEach(c => c.disabled = false);
    }

    function disableControls() {
        [...controls.children].forEach(c => c.disabled = true);

    }

})());
