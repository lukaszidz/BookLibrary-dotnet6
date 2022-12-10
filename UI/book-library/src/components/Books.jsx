import React from "react";
import Select from 'react-select'
import { BOOK_PAGE_SIZE } from "../constants";
import styles from "../styles/app.module.css";
import Paging from './Paging'
import useFilter  from '../api/Api.js'

let [searchKey, searchValue] = [];

const Books = () => {
    const [books, totalCount, filterBooks] = useFilter();

    const onPageClick = (pageIndex) => {
        filterBooks(searchKey, searchValue, pageIndex)
    }

    const handleSubmit = event => {
        event.preventDefault();

        searchKey = event.target.searchKey.value;
        searchValue = event.target.searchValue.value;

        filterBooks(searchKey, searchValue);
    }
    
    return (
    <>
        <div className={styles.header}>
            <h1>Royal Library</h1>
        </div>
        <div className={styles.searchContainer}>
            <form onSubmit={handleSubmit}>
                <div className={styles.row}>
                    <label htmlFor="searchKey">Search By:</label>
                    <Select name='searchKey' className={styles.rowInput} options={[
                                    { value: 'title', label: 'Title '},
                                    { value: 'publisher', label: 'Publisher '},
                                    { value: 'author', label: 'Author' },
                                    { value: 'type', label: 'Type' },
                                    { value: 'isbn', label: 'ISBN' },
                                    { value: 'category', label: 'Category'}
                                ]} />
                </div>

                <div className={styles.row}>
                    <label htmlFor="searchValue">Search Value:</label>
                    <input type="text" name="searchValue" className={styles.rowInput} />
                    <div className={styles.searchFoot}>
                        <input type="submit" value="Search"/>
                    </div>
                </div>                    
            </form>
        </div>

        <table className={styles.bookTable}>
            <thead className={styles.bookHeader}>
                <tr>
                    <th>Book Title</th>
                    <th>Publisher</th>
                    <th>Authors</th>
                    <th>Type</th>
                    <th>ISBN</th>
                    <th>Category</th>
                    <th>Available Copies</th>
                </tr>
            </thead>
            <tbody>
                {books && books.map((el) => (
                    <tr key={el.id}>
                        <td>{el.title}</td>
                        <td>{el.publisher}</td>
                        <td>{el.authors}</td>
                        <td>{el.type}</td>
                        <td>{el.isbn}</td>
                        <td>{el.category}</td>
                        <td>{`${el.availableCopies}/${el.allCopies}`}</td>
                    </tr>
                ))}
            </tbody>
            <tfoot className={styles.bookTableFoot}>
                <tr>
                    <td className={styles.cell} colSpan="100%"><Paging totalCount={totalCount} pageSize={BOOK_PAGE_SIZE} onClick={(i) => onPageClick(i)} /></td>
                </tr>
            </tfoot>
      </table>
    </>);
}

export default Books;