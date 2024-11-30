require('dotenv').config();
const Sequelize = require('sequelize');

// set up sequelize to point to our postgres database
const sequelize = new Sequelize(process.env.DATABASE_URL, {
  //host: 'ep-bitter-bar-a5qhvc2z.us-east-2.aws.neon.tech',
  dialect: 'postgres',
  //port: 5432,
  dialectOptions: {
    ssl: { rejectUnauthorized: false },
  },
});

sequelize
  .authenticate()
  .then(() => {
    console.log('Connection has been established successfully.');
  })
  .catch((err) => {
    console.log('Unable to connect to the database:', err);
  });


  // Define a "Project" model

const Greeting = sequelize.define('Greeting', {
    timeOfDay: Sequelize.STRING,
    language: Sequelize.STRING,
    greetingMessage: Sequelize.STRING,
    tone: Sequelize.STRING,
  });
  
  // synchronize the Database with our models and automatically add the
  // table if it does not exist
  
  sequelize.sync().then(() => {
    // create a new "Project" and add it to the database
    Greeting.bulkCreate([{
      timeOfDay: 'Morning',
      language: 'English',
      greetingMessage: 'Good Morning!',
      tone: 'Formal'
    }, 
    {
        timeOfDay: 'Morning',
        language: 'English',
        greetingMessage: 'Morning!',
        tone: 'Casual'
    },
    {
        timeOfDay: 'Afternoon',
        language: 'English',
        greetingMessage: 'Good Afternoon!',
        tone: 'Formal'
    },
    {
        timeOfDay: 'Afternoon',
        language: 'English',
        greetingMessage: 'Afternoon!',
        tone: 'Casual'
    },
    {
        timeOfDay: 'Evening',
        language: 'English',
        greetingMessage: 'Good Evening!',
        tone: 'Formal'
    },
    {
        timeOfDay: 'Evening',
        language: 'English',
        greetingMessage: 'Evening!',
        tone: 'Casual'
    },
    {
        timeOfDay: 'Morning',
        language: 'French',
        greetingMessage: 'Bon Matin!',
        tone: 'Formal'
    },
    {
        timeOfDay: 'Morning',
        language: 'French',
        greetingMessage: 'Bonjour!',
        tone: 'Casual'
    },
    {
        timeOfDay: 'Afternoon',
        language: 'French',
        greetingMessage: 'Bon Après-midi!',
        tone: 'Formal'
    },
    {
        timeOfDay: 'Afternoon',
        language: 'French',
        greetingMessage: 'Après-midi mon ami!',
        tone: 'Casual'
    },
    {
        timeOfDay: 'Evening',
        language: 'French',
        greetingMessage: 'Bonne nuit!',
        tone: 'Formal'
    },
    {
        timeOfDay: 'Afternoon',
        language: 'French',
        greetingMessage: 'Bonne nuit mon ami!',
        tone: 'Casual'
    },
    {
        timeOfDay: 'Morning',
        language: 'Spanish',
        greetingMessage: 'Buenas Dias!',
        tone: 'Formal'
    },
    {
        timeOfDay: 'Morning',
        language: 'Spanish',
        greetingMessage: 'Hola amigo!',
        tone: 'Casual'
    },
    {
        timeOfDay: 'Afternoon',
        language: 'Spanish',
        greetingMessage: 'Buenas Tardes!',
        tone: 'Formal'
    },
    {
        timeOfDay: 'Afternoon',
        language: 'Spanish',
        greetingMessage: 'Buenas tardes mon amigo!',
        tone: 'Casual'
    },
    {
        timeOfDay: 'Evening',
        language: 'Spanish',
        greetingMessage: 'Buenas noches!',
        tone: 'Formal'
    },
    {
        timeOfDay: 'Evening',
        language: 'Spanish',
        greetingMessage: 'Buenas noches mon amigo!',
        tone: 'Casual'
    },
    ])
      .then((Greeting) => {
        // you can now access the newly created Project via the variable project
        console.log('success!');
      })
      .catch((error) => {
        console.log('something went wrong!');
      });
  });