import React, { useEffect } from 'react';
import logo from './logo.svg';
import { useState} from 'react';
import './App.css';
import axios from 'axios';



function App() {

  // create a basic useState 

  const [activities, setActivities] = useState([]);

  useEffect(()=> {
 // axios contains all your http methods , send a request and returns a promise.

 axios.get('http://localhost:5000/api/activities')
 .then(response => {
   console.log(response);
   setActivities(response.data)
 })
// square brackets indicate firing once

  },[])
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <ul>
          {activities.map((activity:any) =>(
           <li>key={activity.id}
             {activity.title}
            </li>
          ))}

        </ul>
       
        
      </header>
    </div>
  );
}

export default App;
