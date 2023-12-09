// from react and libs
import React from 'react';
import axios from 'axios';
import classNames from 'classnames/bind';
import { useState, useEffect } from 'react';

// components
import styles from './CourseEnrolled.module.scss';
import Image from '~/components/Image';
import Button from '~/components/Button';

const cx = classNames.bind(styles);

const CourseEnrolled = () => {
    return (
        <div className={cx('wrapper')}>
            <h1 className={cx('course-enrolled__title')}>Courses enrolled</h1>
            <div className={cx('course-enrolled')}>
                <Button outline small className={cx('add-more-courses-btn')}>
                    + Add more courses
                </Button>
                <div className={cx('course-enrolled__container')}>
                    <div>
                        <Image src={'https://s.net.vn/MPOH'} className={cx('course-enrolled__image')} />
                    </div>
                    <div className={cx('course-enrolled__content')}>
                        <h2 className={cx('course-enrolled__content-name')}>name</h2>
                        <p className={cx('course-enrolled__content-description')}>description</p>
                        <a href="#" className={cx('course-enrolled__content-view-certificates-link')}>
                            View certificates
                        </a>
                        <br />
                        <span className={cx('course-enrolled__enrolled-date')}>enrolled date</span>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default CourseEnrolled;
