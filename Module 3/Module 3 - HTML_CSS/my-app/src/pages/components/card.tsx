import React from "react";
import {IPerson} from '../../interfaces/IPerson';
import styles from  '../../styles/card.module.css';
import {Link} from "react-router-dom";

interface ICardProps {
    person: IPerson
}

const Card = (props: ICardProps) => {
    const card = props.person;
    return (
        <div className={styles.cardContainer}>
            <div className={styles.name}>Name: {card.name}</div>
            <div className={styles.height}>Height: {card.height}</div>
            <div className={styles.mass}>Mass: {card.mass}</div>
            <div className={styles.skinColor}>Hair Color: {card.hair_color}</div>
            <div className={styles.skinColor}>Skin Color: {card.skin_color}</div>
            <div className={styles.eyeColor}>Eye Color: {card.eye_color}</div>
          
            <Link to={{
                pathname: `/films/${card.name}`,
                state: {films: card.films}
            }}> 
                <button>Go to films</button>
            </Link> 
            
        
        </div>
    );
}

export default Card;
