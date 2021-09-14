import React, { useEffect, useState } from "react";
import styles from  './cards.module.css';
import axios from "axios";
import Card from './card'

const Cards = () => {
    const [people, setPeople] = useState([]);

    useEffect(() => {
        axios.get('https://swapi.dev/api/people')
            .then(response => {
                setPeople(
                    response.data.results
                  );
        })
            .catch(error => {
                console.log(error);
        })
    });

    return (
        <div className={styles.cardsContainer}>
            {
                people.map((person, index) => (
                    <Card key={index} person={person}></Card>
                ))
            }
            </div>
        );
}

export default Cards;