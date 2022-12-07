import React, { useState } from "react";
import Select from 'react-select'
import useFilter  from '../Api'
import styles from "../index.css";

const Books = () => {
    const [books, hasNextPage, filterBooks] = useFilter(); 

    const handleSubmit = event => {
        event.preventDefault();
        filterBooks();
    }
    

    return (
    <>
        <form onSubmit={handleSubmit}>
            <table>
                <tbody>
                    <tr>
                        <td>Search By:</td>
                        <td><Select options={[]} /></td>
                    </tr>
                    <tr>
                        <td>Search Value:</td>
                        <td><input /></td>
                    </tr>
                </tbody>
            </table>
            <input type="submit" value="Search"/>
        </form>

        <table className={styles.table}>
            <thead className={styles.tableRowHeader}>
                <tr>
                    <th className={styles.tableHeader}>Book Title</th>
                    <th className={styles.tableHeader}>Publisher</th>
                    <th className={styles.tableHeader}>Authors</th>
                    <th className={styles.tableHeader}>Type</th>
                    <th className={styles.tableHeader}>ISBN</th>
                    <th className={styles.tableHeader}>Category</th>
                    <th className={styles.tableHeader}>Available Copies</th>
                </tr>
            </thead>
            <tbody>
                {books && books.map((el) => (
                    <tr className={styles.tableRowItems} key={el.id}>
                        <td className={styles.tableCell}>{el.title}</td>
                        <td className={styles.tableCell}>{el.publisher}</td>
                        <td className={styles.tableCell}>{el.authors}</td>
                        <td className={styles.tableCell}>{el.type}</td>
                        <td className={styles.tableCell}>{el.isbn}</td>
                        <td className={styles.tableCell}>{el.category}</td>
                        <td className={styles.tableCell}>{`${el.availableCopies}/${el.allCopies}`}</td>
                    </tr>
                ))}
            </tbody>
      </table>
    </>);
}

export default Books;