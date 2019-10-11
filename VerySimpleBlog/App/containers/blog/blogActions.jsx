import { GET_POSTS_SUCCESS, GET_POSTS_ERROR } from './blogConstants.jsx'
import "isomorphic-fetch"

export function receivePosts(data) {
    return {
        type: GET_POSTS_SUCCESS,
        posts: data
    }
}

export function errorReceive(err) {
    return {
        type: GET_POSTS_ERROR,
        error: err
    }
}