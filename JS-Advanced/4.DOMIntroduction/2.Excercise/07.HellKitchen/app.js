function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   let input = document.querySelector('#inputs>textarea');
   const bestRestaurantResult = document.querySelector('#bestRestaurant>p');
   const bestWorkersResult = document.querySelector('#workers>p');


   function onClick() {

      // convert the input to JSON object
      const arr = JSON.parse(input.value);

      let restaurants = {};


      // iterate trough every record in the JSON object
      // "PizzaHut - Peter 500, George 300, Mark 800"
      arr.forEach(element => {

         // Split the restaraunt and the workers
         const tokens = element.split(' - ')

         // tale the resuarant name
         // PizzaHut
         const name = tokens[0];

         // take and split the workers to array of strings
         // Peter 500, 
         // George 300, 
         // Mark 800
         const workersArr = tokens[1].split(', ');

         let workers = [];

         //iterate trough the strings in workersArr
         for (const worker of workersArr) {

            // split worker to name and salary
            // Peter
            const workerTokens = worker.split(' ');

            // 500
            const salary = Number(workerTokens[1]);

            // create object with name and salary and push it to the array
            // of workers in the current restaurant
            workers.push({ name: workerTokens[0], salary });
         }

         // if restaurant name exist
         if (restaurants[name] !== undefined) {

            // concat the exists workers in the restaurant with the new ones
            workers = workers.concat(restaurants[name].workers)
         }

         // sort workers array descending by salary
         workers.sort((worker1, worker2) => worker2.salary - worker1.salary)

         // get best salary
         let bestSalary = workers[0].salary;

         // get average salary
         let averageSalary = workers.reduce((sum, worker) => sum + worker.salary, 0) / workers.length;

         // create or update key value restaurant {key: name, value: workers[], value: averageSalary, value: bestSalary}
         restaurants[name] = {
            workers,
            averageSalary,
            bestSalary,
         };
      });

      let bestRestaurantSalary = 0;
      let bestRestaurant = undefined;

      // Iterate trough every restaurant
      for (const name in restaurants) {

         // check which restaurant has better bestSalary
         if (restaurants[name].averageSalary > bestRestaurantSalary) {

            // record current restaurant to bestRestaurant variable
            bestRestaurant = {
               name,
               workers: restaurants[name].workers,
               bestSalary: restaurants[name].bestSalary,
               averageSalary: restaurants[name].averageSalary,
            };

            // recored best salary of the restaurant to bestRestaurantSalary
            bestRestaurantSalary = restaurants[name].averageSalary;
         }
      }

      // print the result in restaurant section
      bestRestaurantResult.textContent = `Name: ${bestRestaurant.name} 
      Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`

      // create array to store the workers
      let workersResultStr = [];

      // iterate trough the workers and add to array their records
      bestRestaurant.workers.forEach(worker => {
         workersResultStr.push(`Name: ${worker.name} With Salary:${worker.salary}`);
      })

      // print the result
      bestWorkersResult.textContent = workersResultStr.join('\n');
   }
}

