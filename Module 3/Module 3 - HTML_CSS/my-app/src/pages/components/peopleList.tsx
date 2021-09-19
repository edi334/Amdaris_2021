import React from "react";
import {IPerson} from '../../interfaces/IPerson';
import Card from './card';
import styles from  '../../styles/cards.module.css';

interface PeopleListProps {
    people: IPerson[];
}

const PeopleList = (props: PeopleListProps) => {
    const people = props.people;

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

export default PeopleList