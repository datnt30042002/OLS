// from react and libs
import React from 'react';
import axios from 'axios';
import classNames from 'classnames/bind';
import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

// components
import styles from './CourseDetails.module.scss';
import Button from '~/components/Button';
import config from '~/config';

const cx = classNames.bind(styles);

const CourseDetails = () => {
    return (
        <main className={cx('wrapper')}>
            {/* Grid */}
            <div className={cx('grid')}>
                {/* Row */}
                <div className={cx('row')}>
                    {/* Col */}
                    <div className={'col-9'}>
                        <div className={cx('course-details__info-chapters-lessons-wrap')}>
                            <div className={cx('course-details__info-wrap')}>
                                <div className={cx('course-details__info')}>
                                    <h1 className={cx('course-details__info__name')}>Course name</h1>
                                    <p className={cx('course-details__info__description')}>Description</p>
                                    <p className={cx('course-details__info__info')}>Information</p>
                                </div>
                                <div className={cx('course-details__enroll')}>
                                    <Link to={config.routes.payment}>
                                        <Button primary large className={cx('course-details__enroll-btn')}>
                                            Enroll <br /> Starts Dec 7
                                        </Button>
                                    </Link>
                                </div>
                            </div>
                            <div className={cx('course-details__chapters-lessons-wrap')}>
                                <div className={cx('course-details__chapters')}>
                                    <span className={cx('course-details__chapters-name')}>Chapter name</span>
                                    <br /> <br />
                                    <span className={cx('course-details__chapters-time')}>1 hours</span>
                                    <span className={cx('course-details__chapters-lessons')}>15 lessons</span>
                                </div>

                                <div className={cx('course-details__chapters')}>
                                    <span className={cx('course-details__chapters-name')}>Chapter name</span>
                                    <br /> <br />
                                    <span className={cx('course-details__chapters-time')}>1 hours</span>
                                    <span className={cx('course-details__chapters-lessons')}>15 lessons</span>
                                </div>

                                <div className={cx('course-details__chapters')}>
                                    <span className={cx('course-details__chapters-name')}>Chapter name</span>
                                    <br /> <br />
                                    <span className={cx('course-details__chapters-time')}>1 hours</span>
                                    <span className={cx('course-details__chapters-lessons')}>15 lessons</span>
                                </div>
                            </div>
                        </div>
                    </div>

                    {/* Col */}
                    <div className={cx('col-3')}>
                        <div className={cx('course-details__video-intro')}>
                            <iframe
                                className={cx('course-details__video-intro-img')}
                                width="560"
                                height="315"
                                src="https://www.youtube.com/embed/r6GWbQL-qwA"
                                frameborder="0"
                                allowfullscreen
                            ></iframe>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    );
};

export default CourseDetails;
