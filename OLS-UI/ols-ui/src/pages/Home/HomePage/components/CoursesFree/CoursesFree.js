// from react and libs
import React from 'react';
import classNames from 'classnames/bind';
import { useState, useEffect } from 'react';
import axios from 'axios';

// components
import styles from './CoursesFree.module.scss';
import Image from '~/components/Image';
import Button from '~/components/Button';

const cx = classNames.bind(styles);

const CoursesFree = () => {
    const [courses, setCourses] = useState([]);

    useEffect(() => {
        fetchDataFromApi();
    }, []);

    const fetchDataFromApi = async () => {
        try {
            const response = await axios.get('https://localhost:7158/get15CoursesFree');

            if (response.status !== 200) {
                throw new Error('Network is not ok.');
            }

            setCourses(response.data);
        } catch (error) {
            throw new Error(error.message);
        }
    };

    return (
        <div className={cx('wrapper')}>
            {/* Grid */}
            <div className={cx('grid')}>
                <h1 className={cx('course-heading')}>Courses Free</h1>
                {/* Row */}
                <div className={cx('row')}>
                    {/* Col */}
                    {courses.map((course) => (
                        <div key={course.courseId} className={cx('col-3')}>
                            <div className={cx('course-item')}>
                                <a href="#" className={cx('course-item__link')}>
                                    <Image
                                        src={course.image}
                                        alt={course.courseName}
                                        className={cx('course-item__image')}
                                    />
                                    <div className={cx('course-item__info')}>
                                        <span className={cx('course-item__learningPath')}>
                                            IMAGE + {course.learningPath}
                                        </span>
                                        <span className={cx('course-item__name')}>{course.courseName}</span>
                                        <div className={cx('course-item__footer')}>
                                            <span className={cx('course-item__fee')}></span>
                                            <span className={cx('course-item__course-degree')}>Course / Degree</span>
                                        </div>
                                    </div>
                                    <div className={cx('free')}>
                                        <span className={cx('free-title')}>Free</span>
                                    </div>
                                </a>
                            </div>
                        </div>
                    ))}
                </div>

                {/* Row */}
                <div className={cx('row')}>
                    <div className={cx('show-more')}>
                        <Button outline small className={cx('btn-show-more')}>
                            <span className={cx('btn-show-more__title')}>Show more</span>
                        </Button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default CoursesFree;
