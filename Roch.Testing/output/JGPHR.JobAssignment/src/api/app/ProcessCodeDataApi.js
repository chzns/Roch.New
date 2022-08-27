import request from '@/utils/request'
import store from '@/store'
const baseUrl = process.env.APP_API

export function InsProcessCodeData(data) {
  return store.dispatch('GetDataFilter').then(dataFilter => {
    return request({
      url: baseUrl + '/api/ProcessCodeData/InsProcessCodeData',
      method: 'post',
      data: data
    })
  })
}

export function DelProcessCodeData(data) {
  return store.dispatch('GetDataFilter').then(dataFilter => {
    return request({
      url: baseUrl + '/api/ProcessCodeData/DelProcessCodeData',
      method: 'post',
      data: data
    })
  })
}

export function GetProcessCodeData(data) {
  return store.dispatch('GetDataFilter').then(dataFilter => {
    return request({
      url: baseUrl + '/api/ProcessCodeData/GetProcessCodeData',
      method: 'post',
      data: data
    })
  })
}

export function GetProcessCodeDataMain(data) {
  return store.dispatch('GetDataFilter').then(dataFilter => {
    return request({
      url: baseUrl + '/api/ProcessCodeData/GetProcessCodeDataMain',
      method: 'post',
      data: data
    })
  })
}

export function UpdProcessCodeData(data) {
  return store.dispatch('GetDataFilter').then(dataFilter => {
    return request({
      url: baseUrl + '/api/ProcessCodeData/UpdProcessCodeData',
      method: 'post',
      data: data
    })
  })
}

export function BulkDelProcessCodeData(data) {
  return store.dispatch('GetDataFilter').then(dataFilter => {
    return request({
      url: baseUrl + '/api/ProcessCodeData/BulkDelProcessCodeData',
      method: 'post',
      data: data
    })
  })
}

export function BulkProcessCodeData(data) {
  return store.dispatch('GetDataFilter').then(dataFilter => {
    return request({
      url: baseUrl + '/api/ProcessCodeData/BulkProcessCodeData',
      method: 'post',
      data: data
    })
  })
}

export function BulkValidProcessCodeData(data) {
  return store.dispatch('GetDataFilter').then(dataFilter => {
    return request({
      url: baseUrl + '/api/ProcessCodeData/BulkValidProcessCodeData',
      method: 'post',
      data: data
    })
  })
}

export function BulkConfirmProcessCodeData(data) {
  return store.dispatch('GetDataFilter').then(dataFilter => {
    return request({
      url: baseUrl + '/api/ProcessCodeData/BulkConfirmProcessCodeData',
      method: 'post',
      data: data
    })
  })
}
