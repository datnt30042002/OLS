// from react and libs
import React from 'react';
import axios from 'axios';
import classNames from 'classnames/bind';
import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars, faArrowRight, faPen } from '@fortawesome/free-solid-svg-icons';
import { faComment } from '@fortawesome/free-regular-svg-icons';

// components
import styles from './CourseInProgress.module.scss';
import Button from '~/components/Button';
import config from '~/config';

const cx = classNames.bind(styles);

const CourseInProgress = () => {
    const [activeItem, setActiveItem] = useState(null);

    const handleItemClick = (index) => {
        setActiveItem(activeItem === index ? null : index);
    };

    // Toggle
    const [clickCount, setClickCount] = useState(0);

    const handleToggleMenu = () => {
        setClickCount(clickCount + 1);
    };
    const cx = classNames.bind(styles);

    return (
        <main className={cx('wrapper')}>
            <div className={cx('grid')}>
                <div className={cx('row')}>
                    <div className={cx('col-12')}>
                        <div className={cx('side-bar-wrap')}>
                            <div className={cx('action-wrap')}>
                                <div className={cx('action-menu')} onClick={handleToggleMenu}>
                                    <FontAwesomeIcon icon={faBars} /> <span>Menu</span>
                                </div>

                                <div className={cx('action-next')}>
                                    <span>Next</span> <FontAwesomeIcon icon={faArrowRight} />
                                </div>
                            </div>
                            <nav
                                className={cx('side-bar', {
                                    'menu-open': clickCount % 2 === 1,
                                    'menu-close': clickCount % 2 === 0,
                                })}
                            >
                                <ul className={cx('chapter-list')}>
                                    <h1 className={cx('chapter-list__name')}>chapter name</h1>
                                    {[1, 2, 3].map((item, index) => (
                                        <li
                                            key={index}
                                            className={cx(`lesson-item ${activeItem === index ? 'active' : ''}`)}
                                            onClick={() => handleItemClick(index)}
                                        >
                                            <Link href="#">
                                                <p className={cx('chapter-item__name')}>Item {item}</p>
                                                {activeItem === index && (
                                                    <div className={cx('lesson-item__wrap')}>
                                                        <span className={cx('lesson-item__name')}>
                                                            <p>Content for Item {item}</p>
                                                            <p>Content for Item {item}</p>
                                                            <p>Content for Item {item}</p>
                                                            <p>Content for Item {item}</p>
                                                        </span>
                                                    </div>
                                                )}
                                            </Link>
                                        </li>
                                    ))}
                                </ul>
                            </nav>
                        </div>

                        <section className={cx('content', { 'menu-close': clickCount % 2 === 0 })}>
                            <div className={cx('course-lesson')}>
                                <iframe
                                    className={cx('course-lesson__video')}
                                    src="https://www.youtube.com/embed/r6GWbQL-qwA"
                                    frameborder="0"
                                    allowfullscreen
                                ></iframe>

                                <div className={cx('course-lesson__name-notes-wrap')}>
                                    <span className={cx('course-lesson__name-title')}>Lesson name</span>

                                    <span className={cx('course-lesson__note-title')}>
                                        <FontAwesomeIcon icon={faPen} /> Save notes
                                    </span>
                                </div>
                            </div>
                        </section>

                        <div className={cx('course-comment')}>
                            <FontAwesomeIcon icon={faComment} />
                        </div>
                    </div>
                </div>
            </div>
        </main>
    );
};

export default CourseInProgress;
