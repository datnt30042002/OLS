// from react and libs
import React from 'react';
import axios from 'axios';
import classNames from 'classnames/bind';
import { useState, useEffect } from 'react';

// components
import styles from './NewestBlogs.module.scss';
import Image from '~/components/Image';
import Button from '~/components/Button';

const cx = classNames.bind(styles);

const NewestBlogs = () => {
    const [blogs, setBlogs] = useState([]);

    useEffect(() => {
        getDataFromApi();
    }, []);

    const getDataFromApi = async () => {
        try {
            const response = await axios.get('https://localhost:7158/get10NewestBlogs');

            if (!response.status === 200) {
                throw new Error('Network is not ok. Cannot connect to API.');
            }
            setBlogs(response.data);
        } catch (error) {
            throw new Error(error);
        }
    };

    return (
        <div className={cx('wrapper')}>
            {/* Grid */}
            <div className={cx('grid')}>
                <h1 className={cx('blog-heading')}>Các bài viết mới nhất</h1>
                {/* Row */}
                <div className={cx('row')}>
                    {/* Col */}
                    {blogs.map((blog) => (
                        <div key={blog.blogId} className={cx('col-3')}>
                            <div className={cx('blog-item')}>
                                <a href="#" className={cx('blog-item__link')}>
                                    <Image
                                        src={blog.blogImage}
                                        alt={blog.blogTitle}
                                        className={cx('blog-item__image')}
                                    />
                                    <div className={cx('blog-item__info')}>
                                        <span className={cx('blog-item__topic')}>Chủ đề: Lập trình cuộc sống</span>
                                        <span className={cx('blog-item__name')}>{blog.blogTitle}</span>

                                        <span className={cx('blog-item__author')}>
                                            <Image src={blog.avatar} className={cx('blog-item__author__image')} />
                                            {blog.fullName}
                                        </span>

                                        <div className={cx('blog-item__date-read')}>
                                            <span className={cx('blog-item__post-date')}>
                                                Ngày đăng: {blog.postDate}
                                            </span>
                                            <span className={cx('blog-item__author-read__time')}>
                                                {blog.readTime} phút đọc
                                            </span>
                                        </div>
                                        <div className={cx('blog-item__footer')}>
                                            <span className={cx('blog-item__fragement')}></span>
                                            <span className={cx('blog-item__blog-hashtag')}>Bài viết</span>
                                        </div>
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
                            <span className={cx('btn-show-more__title')}>Hiển thị thêm</span>
                        </Button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default NewestBlogs;
